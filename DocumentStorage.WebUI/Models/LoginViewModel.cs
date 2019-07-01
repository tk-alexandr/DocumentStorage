using System.ComponentModel.DataAnnotations;

namespace DocumentStorage.WebUI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Пожалуста, введите имя пользователя")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Пожалуста, введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}