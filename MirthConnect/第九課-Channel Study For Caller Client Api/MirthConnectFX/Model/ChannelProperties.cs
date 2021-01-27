using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable]
    public class ChannelProperties
    {
        [XmlAttribute("version")]
        public string Version { get; set; }
        [XmlElement("initialState")]
        public DeployedState InitialState { get; set; }
        [XmlElement("clearGlobalChannelMap")]
        public string ClearGlobalChannelMap { get; set; }

        [XmlElement("messageStorageMode")]
        public string MessageStorageMode { get; set; }
        [XmlElement("storeAttachments")]
        public bool? StoreAttachments { get; set; }
        [XmlElement("removeContentOnCompletion")]
        public bool? RemoveContentOnCompletion { get; set; }
        [XmlElement("removeAttachmentsOnCompletion")]
        public bool? RemoveAttachmentsOnCompletion { get; set; }
        [XmlElement("encryptData")]
        public bool? EncryptData { get; set; }
        [XmlElement("removeOnlyFilteredOnCompletion")]
        public bool? RemoveOnlyFilteredOnCompletion { get; set; }

        [XmlElement("pruneMetaDataDays")]
        public int? PruneMetaDataDays { get; set; }
        [XmlElement("pruneContentDays")]
        public int? PruneContentDays { get; set; }
        [XmlElement("archiveEnabled")]
        public bool? ArchiveEnabled { get; set; }

        [XmlElement("metaDataColumns")]
        public MetaDataColumnList MetaDataColumns { get; set; }

        [XmlArray("tags"), XmlArrayItem("string")]
        public List<string> Tags { get; set; }

        [XmlElement("resourceIds")]
        public HashMapData ResourceIds { get; set; }

        [XmlElement("attachmentProperties")]
        public AttachmentProperty AttachmentProperties { get; set; }


        public bool ShouldSerializeTags()
        {
            if(Tags != null)
                if (Tags.Count > 0)
                    return true;

            return false;
        }

        public bool ShouldSerializeRemoveOnlyFilteredOnCompletion() => RemoveOnlyFilteredOnCompletion.HasValue; 
        public bool ShouldSerializeClearGlobalChannelMap() => ClearGlobalChannelMap != null;
        public bool ShouldSerializeMessageStorageMode() => MessageStorageMode != null;
        public bool ShouldSerializeStoreAttachments() => StoreAttachments.HasValue;
        public bool ShouldSerializeRemoveContentOnCompletion() => RemoveContentOnCompletion.HasValue;
        public bool ShouldSerializeRemoveAttachmentsOnCompletion() => RemoveAttachmentsOnCompletion.HasValue;
        public bool ShouldSerializeEncryptData() => EncryptData.HasValue;
        public bool ShouldSerializeArchiveEnabled() => ArchiveEnabled.HasValue;
        public bool ShouldSerializePruneMetaDataDays() => PruneMetaDataDays.HasValue;
        public bool ShouldSerializePruneContentDays() => PruneContentDays.HasValue;
    }
}


