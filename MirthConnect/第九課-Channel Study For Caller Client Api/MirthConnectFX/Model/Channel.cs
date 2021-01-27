using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable]
    [XmlRoot("channel")]
    public class Channel
    {
        private string _UndeployScript;
        private string _DeployScript;
        private string _PostprocessingScript;
        private string _PreprocessingScript;

        [XmlAttribute("version")]
        public string Version { get; set; }
        [XmlElement("id")]
        public string Id { get; set; }
        [XmlElement("nextMetaDataId")]
        public string NextMetaDataId { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("description")]
        public string Description { get; set; }
        //[XmlElement("enabled")]
        //public bool Enabled { get; set; }
        [XmlElement("revision")]
        public int Revision { get; set; }
        //[XmlElement("lastModified")]
        //public MirthDateTime LastModified { get; set; }
        [XmlElement("sourceConnector")]
        public Connector SourceConnector { get; set; }
        [XmlArray("destinationConnectors"), XmlArrayItem("connector")]
        public Connector[] DestinationConnectors { get; set; }


        [XmlElement("preprocessingScript")]
        public string PreprocessingScript { get; set; } //{ get => "\t\n" + _PreprocessingScript; set { _PreprocessingScript = value; } }
        [XmlElement("postprocessingScript")]
        public string PostprocessingScript { get; set; } //{ get => "\t\n" + _PostprocessingScript; set { _PostprocessingScript = value; } }
        [XmlElement("deployScript")]
        public string DeployScript { get; set; } //{ get => "\t\n" + _DeployScript; set { _DeployScript = value; } }
        [XmlElement("undeployScript")]
        public string UndeployScript { get; set; } //{ get => "\t\n" + _UndeployScript; set { _UndeployScript = value; } }
        [XmlElement("properties")]
        public ChannelProperties Properties { get; set; }

        public ReadOnlyCollection<Connector> GetAllEnabledConnectors()
        {
            var list = new List<Connector>();
            list.Add(SourceConnector);
            list.AddRange(DestinationConnectors.Where(x => x.Enabled));
            return list.AsReadOnly();
        }

        public Channel CreateNew()
        {
            var ret = new Channel();

            ret.Id = Guid.NewGuid().ToString();
            //ret.LastModified = new MirthDateTime() { Time = ulong.Parse(DateTime.Now.ToFileTime().ToString()), Timezone = TimeZone.CurrentTimeZone.ToString()};
            ret.Name = this.Name;
            ret.Description = this.Description;
            ret.NextMetaDataId = this.NextMetaDataId;
            //ret.SourceConnector.Enabled = this.SourceConnector.Enabled;
            ret.Version = this.Version;
            ret.Revision = this.Revision;
            ret.SourceConnector = this.SourceConnector;
            ret.DestinationConnectors = this.DestinationConnectors; ;
            ret.Properties = this.Properties;
            ret.PreprocessingScript = this.PreprocessingScript;
            ret.PostprocessingScript = this.PostprocessingScript;
            ret.DeployScript = this.DeployScript;
            ret.UndeployScript = this.UndeployScript;

            return ret;
        }
    }
}