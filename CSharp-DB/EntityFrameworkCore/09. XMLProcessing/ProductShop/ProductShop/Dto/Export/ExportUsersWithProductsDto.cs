using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dto.Export
{
    [XmlType("User")]
    public class ExportUsersWithProductsDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age", IsNullable = true)]
        public int? Age { get; set; }

        [XmlElement("SoldProducts")]
        public ExportUsersWithProductCountDto SoldProducts { get; set; }
    }
}
