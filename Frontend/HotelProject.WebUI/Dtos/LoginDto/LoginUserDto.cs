using System.ComponentModel.DataAnnotations;


namespace HotelProject.WebUI.Dtos.LoginDto
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "Username needed")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Password needed")]
        public string? Password { get; set; }
    }
}
