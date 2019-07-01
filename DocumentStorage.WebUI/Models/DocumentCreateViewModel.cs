using System.ComponentModel.DataAnnotations;

namespace DocumentStorage.WebUI.Models
{
    public class DocumentCreateViewModel
    {

        [Required(ErrorMessage = "Пожалуйста, укажите название документа")]
        [StringLength(int.MaxValue, MinimumLength = 3, ErrorMessage = "Название должно состоять минимум из 3х букв")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Невозможно создать пустой документ. Пожалуйста, добавьте содержание")]
        [StringLength(int.MaxValue, MinimumLength = 3, ErrorMessage = "Минимальная длинна текста документа - 3 буквы")]
        public string Content { get; set; }
    }
}