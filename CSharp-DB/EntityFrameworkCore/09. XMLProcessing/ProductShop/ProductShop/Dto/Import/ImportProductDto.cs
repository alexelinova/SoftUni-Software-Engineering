using System.Xml.Serialization;

namespace ProductShop.Dto.Import
{
    [XmlType("Product")]
    public class ImportProductDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("sellerId")]
        public int SellerId { get; set; }

        [XmlElement("buyerId", IsNullable = true)]
        public int? BuyerId { get; set; }
    }
}
