using System.ComponentModel.DataAnnotations;

namespace ASPNETCORE.VUE.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}