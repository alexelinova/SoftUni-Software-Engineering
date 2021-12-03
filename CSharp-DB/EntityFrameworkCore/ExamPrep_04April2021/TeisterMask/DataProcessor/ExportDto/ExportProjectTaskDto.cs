using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Task")]
    public class ExportProjectTaskDto
    {
        [XmlElement("Name")]
        public string TaskName { get; set; }

        [XmlElement("Label")]
        public string Label { get; set; }
    }
}
