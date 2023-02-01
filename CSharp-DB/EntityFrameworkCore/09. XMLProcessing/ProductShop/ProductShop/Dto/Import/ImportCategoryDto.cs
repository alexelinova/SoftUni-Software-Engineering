using System.Xml.Serialization;

namespace ProductShop.Dto.Import
{
    [XmlType("Category")]
    public class ImportCategoryDto
    {
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
