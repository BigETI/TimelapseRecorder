using MaterialSkin;
using MaterialSkin.Controls;
using NGif;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace TimelapseRecorder
{
    public partial class MainForm : MaterialForm
    {
        private const string CONFIG_FILE_NAME = "./config.json";

        private const string ERROR_LOG_FILE_NAME = "./error.log";

        private Config config = null;

        private bool recording = false;

        List<Image> images = null;

        private string DirectoryPath
        {
            get
            {
                string ret = directoryTextField.Text.Trim();
                if (ret.Length > 0)
                {
                    if (ret[ret.Length - 1] != Path.DirectorySeparatorChar)
                        ret += Path.DirectorySeparatorChar;
                }
                return ret;
            }
            set
            {
                directoryTextField.Text = value.Trim();
            }
        }

        private EFileType FileType
        {
            get
            {
                return (EFileType)(fileTypeComboBox.SelectedIndex);
            }
            set
            {
                fileTypeComboBox.SelectedIndex = (int)value;
            }
        }

        private uint ScreenIndex
        {
            get
            {
                return (uint)((screensComboBox.SelectedIndex >= Screen.AllScreens.Length) ? (Screen.AllScreens.Length - 1) : screensComboBox.SelectedIndex);
            }
            set
            {
                screensComboBox.SelectedIndex = (value >= Screen.AllScreens.Length) ? (Screen.AllScreens.Length - 1) : (int)value;
            }
        }

        private uint Interval
        {
            get
            {
                uint ret = 0U;
                uint divisor;
                uint divider;
                if (uint.TryParse(divisorTextField.Text, out divisor))
                {
                    if (uint.TryParse(dividerTextField.Text, out divider))
                        ret = (divider * 1000U) / divisor;
                }
                return ret;
            }
        }

        private string FileExtension
        {
            get
            {
                EFileType file_type = FileType;
                return (file_type == EFileType.AnimatedGIF) ? "GIF" : file_type.ToString();
            }
        }

        private string NextFileName
        {
            get
            {
                string ret;
                uint index = 0U;
                string dir = DirectoryPath;
                do
                {
                    ++index;
                    ret = dir + index + "." + FileExtension;
                } while (File.Exists(ret));
                return ret;
            }
        }

        public MainForm()
        {
            InitializeComponent();

            // Initialize MaterialSkin
            MaterialSkinManager manager = MaterialSkinManager.Instance;
            manager.AddFormToManage(this);
            manager.Theme = MaterialSkinManager.Themes.LIGHT;
            manager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            // Fill file types combo box
            foreach (EFileType file_type in Enum.GetValues(typeof(EFileType)))
                fileTypeComboBox.Items.Add(file_type);

            // Fill screens to combo box
            Screen[] screens = Screen.AllScreens;
            for (int i = 0; i < screens.Length; i++)
            {
                Screen screen = screens[i];
                screensComboBox.Items.Add("[Display " + (i + 1) + "] " + screen.Bounds.Width + "x" + screen.Bounds.Height + " " + screen.BitsPerPixel + " bits" + (screen.Primary ? " (Primary) " : ""));
            }


            // Load config file
            if (File.Exists(CONFIG_FILE_NAME))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(CONFIG_FILE_NAME))
                    {
                        config = Config.Read(reader.BaseStream);
                    }
                }
                catch (Exception e)
                {
                    WriteError(e.Message);
                }
            }
            if (config == null)
                config = new Config(Directory.GetCurrentDirectory() + "\\recordings");
            DirectoryPath = config.recordingsPath;
            FileType = config.fileType;
            ScreenIndex = config.screenIndex;
        }

        private void SetControlsControllable(bool state)
        {
            directoryTextField.Enabled = state;
            divisorTextField.Enabled = state;
            dividerTextField.Enabled = state;
        }

        private void WriteError(string msg, bool show = true)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(ERROR_LOG_FILE_NAME))
                {
                    DateTime now = DateTime.Now;
                    writer.WriteLine("[" + now.ToShortDateString() + " " + now.ToShortTimeString() + "] " + msg);
                }
            }
            catch
            {
                //
            }
            if (show)
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void showInFileExplorerButton_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(DirectoryPath))
                Process.Start("explorer.exe", DirectoryPath);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(CONFIG_FILE_NAME))
                {
                    config.Write(writer.BaseStream);
                }
            }
            catch (Exception _e)
            {
                WriteError(_e.Message);
            }

        }

        private void directoryTextField_TextChanged(object sender, EventArgs e)
        {
            config.recordingsPath = DirectoryPath;
        }

        private void fileTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            config.fileType = (EFileType)(fileTypeComboBox.SelectedIndex);
        }

        private void startRecordingButton_Click(object sender, EventArgs e)
        {
            if (recording)
            {
                recording = false;
                recordingTimer.Stop();
                if (FileType == EFileType.AnimatedGIF)
                {
                    if (images != null)
                    {
                        AnimatedGifEncoder encoder = new AnimatedGifEncoder();
                        encoder.Start(NextFileName);
                        encoder.SetDelay(17);
                        encoder.SetRepeat(0);
                        encoder.SetQuality(20);
                        foreach (Image image in images)
                            encoder.AddFrame(image);
                        encoder.Finish();
                        foreach (Image image in images)
                            image.Dispose();
                        images.Clear();
                        images = null;
                    }
                }
            }
            else
            {
                bool success = false;
                if (Directory.Exists(DirectoryPath))
                    success = true;
                else
                {
                    DialogResult result = MessageBox.Show("Directory \"" + DirectoryPath + "\" doesn't exist. Do you want to create this directory?", "Create directory", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.None;
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            Directory.CreateDirectory(DirectoryPath);
                            if (Directory.Exists(DirectoryPath))
                                success = true;
                            else
                                MessageBox.Show("Error at creating directory \"" + DirectoryPath + "\"", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception _e)
                        {
                            WriteError(_e.Message);
                        }
                    }
                }
                if (success)
                {
                    recording = true;
                    recordingTimer.Interval = (int)Interval;
                    recordingTimer.Start();
                }
            }
            SetControlsControllable(!recording);
            startRecordingButton.Text = recording ? "Stop recording" : "Start recording";
        }

        private void divisorTextField_TextChanged(object sender, EventArgs e)
        {
            uint t;
            if (uint.TryParse(divisorTextField.Text, out t))
            {
                if (t == 0U)
                    divisorTextField.Text = "1";
            }
            else
                divisorTextField.Text = "1";
        }

        private void dividerTextField_TextChanged(object sender, EventArgs e)
        {
            uint t;
            if (uint.TryParse(dividerTextField.Text, out t))
            {
                if (t == 0U)
                    dividerTextField.Text = "1";
            }
            else
                dividerTextField.Text = "1";
        }

        private void screensComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            config.screenIndex = (uint)(screensComboBox.SelectedIndex);
        }

        private void recordingTimer_Tick(object sender, EventArgs e)
        {
            Screen screen = Screen.AllScreens[ScreenIndex];
            Bitmap bitmap = new Bitmap(screen.Bounds.Width, screen.Bounds.Height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.CopyFromScreen(screen.Bounds.X, screen.Bounds.Y, 0, 0, bitmap.Size);
            }
            //bitmap = new Bitmap(bitmap, bitmap.Width / 8, bitmap.Height / 8);
            ImageFormat image_format = null;
            EFileType file_type = FileType;
            switch (file_type)
            {
                case EFileType.JPG:
                    image_format = ImageFormat.Jpeg;
                    break;
                case EFileType.PNG:
                    image_format = ImageFormat.Png;
                    break;
                case EFileType.BMP:
                    image_format = ImageFormat.Bmp;
                    break;
                case EFileType.GIF:
                    image_format = ImageFormat.Gif;
                    break;
            }
            try
            {
                if (file_type == EFileType.AnimatedGIF)
                {
                    if (images == null)
                        images = new List<Image>();
                    images.Add(bitmap);
                }
                else
                {
                    bitmap.Save(NextFileName, image_format);
                    bitmap.Dispose();
                }
            }
            catch (Exception _e)
            {
                WriteError(_e.Message, false);
            }
        }
    }
}
