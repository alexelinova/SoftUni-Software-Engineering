using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProductShop.Dto.Export
{
    [XmlType("User")]
    public class ExportSoldProductCountDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlArray("soldProducts")]
        public List<ExportSoldProductDto> SoldProducts { get; set; }
    }
}
