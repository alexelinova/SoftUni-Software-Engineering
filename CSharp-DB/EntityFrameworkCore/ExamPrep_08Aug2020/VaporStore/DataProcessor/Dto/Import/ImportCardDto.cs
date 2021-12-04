using System.ComponentModel.DataAnnotations;
using VaporStore.Common;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportCardDto
    {
        [Required]
        [RegularExpression(GlobalConstants.CardNumberRegex)]
        public string Number { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.CardCVCRegex)]
        public string CVC { get; set; }

        [Required]
        public CardType? Type { get; set; }
    }
}
