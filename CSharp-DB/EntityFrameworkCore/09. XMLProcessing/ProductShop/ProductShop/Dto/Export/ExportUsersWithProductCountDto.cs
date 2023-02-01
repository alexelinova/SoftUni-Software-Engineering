using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProductShop.Dto.Export
{
    [XmlType("SoldProducts")]
    public class ExportUsersWithProductCountDto
    {
        [XmlElement("count")]
        public int ProductsCount { get; set; }

        [XmlArray("products")]
        public List<ExportProductDto> Products { get; set; }
    }
}