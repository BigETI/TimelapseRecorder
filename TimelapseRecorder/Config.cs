using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace TimelapseRecorder
{
    [DataContract]
    public class Config
    {
        private static DataContractJsonSerializer contract = new DataContractJsonSerializer(typeof(Config));

        [DataMember]
        public string recordingsPath = "";

        [DataMember]
        public EFileType fileType = EFileType.JPG;

        [DataMember]
        public uint divident = 1U;

        [DataMember]
        public uint divisor = 1U;

        [DataMember]
        public uint screenIndex = 0;

        public Config()
        {
            //
        }

        public Config(string recordingsPath)
        {
            this.recordingsPath = recordingsPath;
        }

        public void Write(Stream stream)
        {
            if (stream != null)
            {
                if (stream.CanWrite)
                    contract.WriteObject(stream, this);
            }
        }

        public static Config Read(Stream stream)
        {
            Config ret = null;
            if (stream != null)
            {
                if (stream.CanRead)
                    ret = (Config)(contract.ReadObject(stream));
            }
            return ret;
        }
    }
}
