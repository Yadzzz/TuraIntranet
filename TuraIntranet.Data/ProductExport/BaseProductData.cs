using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuraIntranet.Data.ProductExport
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class BaseProductRoot
    {
        [JsonProperty("fields")]
        public BaseProductFields Fields { get; set; }

        [JsonProperty("fieldTemplateSystemId")]
        public string FieldTemplateSystemId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("relationshipLinks")]
        public List<object> RelationshipLinks { get; set; }

        [JsonProperty("systemId")]
        public string SystemId { get; set; }

        [JsonProperty("accessControlList")]
        public List<AccessControlList> AccessControlList { get; set; }
    }

    public class AccessControlList
    {
        [JsonProperty("groupSystemId")]
        public string GroupSystemId { get; set; }

        [JsonProperty("operation")]
        public string Operation { get; set; }
    }

    public class BaseProductFields
    {
        [JsonProperty("_name")]
        public BaseProductName Name { get; set; }
    }

    public class BaseProductName
    {
        [JsonProperty("nb-NO")]
        public string NbNO { get; set; }

        [JsonProperty("fi-FI")]
        public string FiFI { get; set; }

        [JsonProperty("en-US")]
        public string EnUS { get; set; }

        [JsonProperty("sv-SE")]
        public string SvSE { get; set; }

        [JsonProperty("da-DK")]
        public string DaDK { get; set; }
    }
}
