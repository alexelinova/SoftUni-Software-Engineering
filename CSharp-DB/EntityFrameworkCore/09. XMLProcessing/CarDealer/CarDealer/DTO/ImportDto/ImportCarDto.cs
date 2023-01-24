using System.Collections.Generic;
using System.Xml.Serialization;

namespace CarDealer.DTO.ImportDto
{
    [XmlType("Car")]
    public class ImportCarDto
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts")]
        public List<ImportCarPartDto> Parts { get; set; } = new List<ImportCarPartDto>();
    }
}
