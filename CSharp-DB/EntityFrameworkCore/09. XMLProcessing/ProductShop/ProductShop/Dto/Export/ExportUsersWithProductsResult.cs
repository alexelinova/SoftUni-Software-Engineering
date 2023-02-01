using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dto.Export
{
    [XmlType("Users")]
    public class ExportUsersWithProductsResult
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public List<ExportUsersWithProductsDto> Users { get; set; }
    }
}
