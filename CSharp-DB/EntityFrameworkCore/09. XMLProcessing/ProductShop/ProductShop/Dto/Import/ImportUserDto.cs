using System.Xml.Serialization;

namespace ProductShop.Dto.Import
{
    [XmlType("User")]
    public class ImportUserDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age", IsNullable = true)]
        public int? Age { get; set; }
    }
}
