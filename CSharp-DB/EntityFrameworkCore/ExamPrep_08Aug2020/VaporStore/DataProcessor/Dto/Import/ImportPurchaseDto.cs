using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using VaporStore.Common;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{

    [XmlType("Purchase")]
    public class ImportPurchaseDto
    {
        [XmlAttribute("title")]
        [Required]
        public string  Title { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.CardNumberRegex)]
        public string Card { get; set; }

        [Required]
        public PurchaseType? Type { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.PurchaseKeyRegex)]
        public string Key { get; set; }

        [Required]
        public string Date { get; set; }
    }
}
