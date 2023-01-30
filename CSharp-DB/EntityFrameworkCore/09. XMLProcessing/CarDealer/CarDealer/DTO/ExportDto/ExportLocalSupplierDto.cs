using System.Xml.Serialization;

namespace CarDealer.DTO.ExportDto
{
    //for Judge type = "suplier"

    [XmlType("supplier")]
    public class ExportLocalSupplierDto
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("parts-count")]
        public string PartsCount { get; set; }
    }
}
