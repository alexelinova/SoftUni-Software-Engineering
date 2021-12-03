using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using TeisterMask.Common;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Task")]
    public class ImportProjectTaskDto
    {
        [XmlElement("Name")]
        [Required]
        [MaxLength(GlobalConstants.TaskNameMaxLength)]
        [MinLength(GlobalConstants.TaskNameMinLength)]
        public string Name { get; set; }

        [Required]
        [XmlElement("OpenDate")]
        public string OpenDate { get; set; }

        [Required]
        [XmlElement("DueDate")]
        public string DueDate { get; set; }

        [XmlElement("ExecutionType")]
        [Range(GlobalConstants.TaskExecTypeMinValue, GlobalConstants.TaskExecTypeMaxValue)]
        public int ExecutionType { get; set; }

     
        [XmlElement("LabelType")]
        [Range(GlobalConstants.TaskLabelTypeMinValue, GlobalConstants.TaskLabeLTypeMaxValue)]
        public int LabelType { get; set; }
    }
}
