using System;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable]
    public class Step
    {
        private string _Script;

        [XmlElement("sequenceNumber")]
        public int SequenceNumber { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("script")]
        public string Script { get; set; } //{ get => "\t\n" + _Script; set { _Script = value; } }

        [XmlElement("type")]
        public string Type { get; set; }

        [XmlElement("data")]
        public HashMapData Data { get; set; }
    }
}