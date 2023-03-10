using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuraIntranet.Data.ProductExport;

namespace TuraIntranet.Data.ProductExport
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public class VariantRoot
    {
        public string baseProductSystemId { get; set; }
        public List<object> bundledVariants { get; set; }
        public List<object> bundleOfVariants { get; set; }
        public Fields fields { get; set; }
        public string id { get; set; }
        public List<object> relationshipLinks { get; set; }
        public long sortIndex { get; set; }
        public string systemId { get; set; }
        public List<ChannelLink> channelLinks { get; set; }
    }

    public class Activeinternet
    {
        [JsonProperty("*")]
        public bool data { get; set; }
    }

    public class Activitycode
    {
        [JsonProperty("*")]
        public List<int> data { get; set; }
    }

    public class Brand
    {
        [JsonProperty("nb-NO")]
        public string nbNO { get; set; }

        [JsonProperty("fi-FI")]
        public string fiFI { get; set; }

        [JsonProperty("en-US")]
        public string enUS { get; set; }

        [JsonProperty("sv-SE")]
        public string svSE { get; set; }

        [JsonProperty("da-DK")]
        public string daDK { get; set; }
    }

    public class ChannelLink
    {
        public string channelSystemId { get; set; }
    }

    public class Color
    {
        [JsonProperty("nb-NO")]
        public List<string> nbNO { get; set; }
    }

    public class Countryoforigin
    {
        [JsonProperty("*")]
        public List<string> data { get; set; }
    }

    public class Datecreated
    {
        [JsonProperty("*")]
        public DateTime data { get; set; }
    }

    public class Datemodified
    {
        [JsonProperty("*")]
        public DateTime data { get; set; }
    }

    public class Eancode
    {
        [JsonProperty("*")]
        public string data { get; set; }
    }

    public class Eucommoditycode
    {
        [JsonProperty("*")]
        public string data { get; set; }
    }

    public class Fields
    {
        public Name _name { get; set; }
        public Url _url { get; set; }
        public Color color { get; set; }
        public WYSIWYG WYSIWYG { get; set; }
        public News News { get; set; }
        public Brand brand { get; set; }
        public Webname webname { get; set; }
        public Activitycode activitycode { get; set; }
        public Height height { get; set; }
        public Datemodified datemodified { get; set; }
        public Nocommoditycode nocommoditycode { get; set; }
        public Countryoforigin countryoforigin { get; set; }
        public Vendoritemno vendoritemno { get; set; }
        public Itemreplace itemreplace { get; set; }
        public Itemtype itemtype { get; set; }
        public Packaging packaging { get; set; }
        public Grossweight grossweight { get; set; }
        public Volume volume { get; set; }
        public Notdivisibleunit notdivisibleunit { get; set; }
        public Netweight netweight { get; set; }
        public Packagingpallet packagingpallet { get; set; }
        public Packagingmaster packagingmaster { get; set; }
        public Unspsccode unspsccode { get; set; }
        public Datecreated datecreated { get; set; }
        public Itemfeecode itemfeecode { get; set; }
        public Eucommoditycode eucommoditycode { get; set; }
        public Eancode eancode { get; set; }
        public Salesunit salesunit { get; set; }
        public Replacesitem replacesitem { get; set; }
        public Width width { get; set; }
        public Images _images { get; set; }
        public Length length { get; set; }
        public Activeinternet activeinternet { get; set; }
    }

    public class Grossweight
    {
        [JsonProperty("*")]
        public double data { get; set; }
    }

    public class Height
    {
        [JsonProperty("*")]
        public double data { get; set; }
    }

    public class Images
    {
        [JsonProperty("*")]
        public List<string> data { get; set; }
    }

    public class Itemfeecode
    {
        [JsonProperty("*")]
        public string data { get; set; }
    }

    public class Itemreplace
    {
        [JsonProperty("*")]
        public string data { get; set; }
    }

    public class Itemtype
    {
        [JsonProperty("*")]
        public List<int> data { get; set; }
    }

    public class Length
    {
        [JsonProperty("*")]
        public double data { get; set; }
    }

    public class Name
    {
        [JsonProperty("nb-NO")]
        public string nbNO { get; set; }

        [JsonProperty("fi-FI")]
        public string fiFI { get; set; }

        [JsonProperty("en-US")]
        public string enUS { get; set; }

        [JsonProperty("sv-SE")]
        public string svSE { get; set; }

        [JsonProperty("da-DK")]
        public string daDK { get; set; }
    }

    public class Netweight
    {
        [JsonProperty("*")]
        public double data { get; set; }
    }

    public class News
    {
        [JsonProperty("nb-NO")]
        public DateTime nbNO { get; set; }

        [JsonProperty("fi-FI")]
        public DateTime fiFI { get; set; }

        [JsonProperty("en-US")]
        public DateTime enUS { get; set; }

        [JsonProperty("sv-SE")]
        public DateTime svSE { get; set; }

        [JsonProperty("da-DK")]
        public DateTime daDK { get; set; }
    }

    public class Nocommoditycode
    {
        [JsonProperty("*")]
        public string data { get; set; }
    }

    public class Notdivisibleunit
    {
        [JsonProperty("*")]
        public bool data { get; set; }
    }

    public class Packaging
    {
        [JsonProperty("*")]
        public int data { get; set; }
    }

    public class Packagingmaster
    {
        [JsonProperty("*")]
        public int data { get; set; }
    }

    public class Packagingpallet
    {
        [JsonProperty("*")]
        public int data { get; set; }
    }

    public class Replacesitem
    {
        [JsonProperty("*")]
        public string data { get; set; }
    }

    public class Salesunit
    {
        [JsonProperty("*")]
        public List<string> data { get; set; }
    }

    public class Unspsccode
    {
        [JsonProperty("*")]
        public string data { get; set; }
    }

    public class Url
    {
        [JsonProperty("nb-NO")]
        public string nbNO { get; set; }

        [JsonProperty("fi-FI")]
        public string fiFI { get; set; }

        [JsonProperty("en-US")]
        public string enUS { get; set; }

        [JsonProperty("sv-SE")]
        public string svSE { get; set; }

        [JsonProperty("da-DK")]
        public string daDK { get; set; }
    }

    public class Vendoritemno
    {
        [JsonProperty("*")]
        public string data { get; set; }
    }

    public class Volume
    {
        [JsonProperty("*")]
        public string data { get; set; }
    }

    public class Webname
    {
        [JsonProperty("en-US")]
        public string enUS { get; set; }

        [JsonProperty("sv-SE")]
        public string svSE { get; set; }

        [JsonProperty("da-DK")]
        public string daDK { get; set; }
    }

    public class Width
    {
        [JsonProperty("*")]
        public double data { get; set; }
    }

    public class WYSIWYG
    {
        [JsonProperty("nb-NO")]
        public string nbNO { get; set; }

        [JsonProperty("en-US")]
        public string enUS { get; set; }

        [JsonProperty("sv-SE")]
        public string svSE { get; set; }

        [JsonProperty("da-DK")]
        public string daDK { get; set; }
    }
}
