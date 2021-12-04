using System;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType("Prisoner")]
    public class ExportPrisonerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IncarcerationDate { get; set; }

        [XmlArray("EncryptedMessages")]
        public ExportMessageDto[] EncryptedMessages { get; set; }
    }
}
