using System.Xml.Serialization;

namespace CarDealer.DTO.ImportDto
{
    [XmlType("partId")]
    public class ImportCarPartDto
    {
        [XmlAttribute("id")]
        public int PartId{ get; set; }
    }
}
