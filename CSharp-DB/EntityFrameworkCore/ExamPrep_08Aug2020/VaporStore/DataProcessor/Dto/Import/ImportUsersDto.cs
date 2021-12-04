using System.ComponentModel.DataAnnotations;
using VaporStore.Common;

namespace VaporStore.DataProcessor.Dto.Import
{

    public class ImportUsersDto
    {
        [Required]
        [RegularExpression(GlobalConstants.UserFullNameRegex)]
        public string FullName { get; set; }

        [Required]
        [MinLength(GlobalConstants.UsernameMinLength)]
        [MaxLength(GlobalConstants.UsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Range(GlobalConstants.UserMinAgeValue, GlobalConstants.UserMaxAgeValue)]
        public int Age { get; set; }

        public ImportCardDto[] Cards { get; set; }
    }
}
