using System.ComponentModel.DataAnnotations;
namespace BulkyWeb_1._0.Models.DTO
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
