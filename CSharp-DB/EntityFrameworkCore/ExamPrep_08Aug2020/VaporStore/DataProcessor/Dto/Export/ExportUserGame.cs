using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("User")]
    public class ExportUserGame
    {
        [XmlAttribute("username")]
        public string Username { get; set; }

        [XmlArray]
        public ExportPurchaseDto[] Purchases { get; set; }

        public decimal TotalSpent { get; set; }
    }
}
