using System.ComponentModel.DataAnnotations;


namespace HotelProject.WebUI.Dtos.LoginDto
{
    public class LoginUserDto
    {
        // boş giderken hata atıyor....
        private string _value = "default";
        private string? _username;

        [Required(ErrorMessage = "Username needed")]
        public string? Username
        {
            // username bos mu null mı kalmis -- oyleyse null  -- degilse username dolar ve set olur --
            get => _username ?? _value;
            set => _username = string.IsNullOrWhiteSpace(value) ? null : value;
        }

        [Required(ErrorMessage = "password needed")]
        public string? Password { get; set; }


    }
}
