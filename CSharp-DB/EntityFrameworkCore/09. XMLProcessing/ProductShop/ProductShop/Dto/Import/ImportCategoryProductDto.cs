using System.Xml.Serialization;

namespace ProductShop.Dto.Import
{
    [XmlType("CategoryProduct")]
    public class ImportCategoryProductDto
    {
        [XmlElement]
        public string CategoryId { get; set; }

        [XmlElement]
        public string ProductId { get; set; }

    }
}
