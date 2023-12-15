using System.ComponentModel.DataAnnotations;    // bunu eklemezsen çalışmaz

namespace HotelProject.WebUI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage = "add name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "add surname")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "add username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "add mail")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "add password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "confirm password")]
        [Compare("Password",ErrorMessage = "passwords don't match")]
        public string ConfirmPassword { get; set; }

    }
}
