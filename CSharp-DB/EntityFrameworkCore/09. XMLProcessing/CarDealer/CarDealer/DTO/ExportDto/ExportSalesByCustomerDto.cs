using System.Xml.Serialization;

namespace CarDealer.DTO.ExportDto
{
    [XmlType("customer")]
    public class ExportSalesByCustomerDto
    {
        [XmlAttribute("full-name")]
        public string Name { get; set; }

        [XmlAttribute("bought-cars")]
        public string CountOfCars { get; set; }

        [XmlAttribute("spent-money")]
        public decimal SpentMoney { get; set; }
    }
}
