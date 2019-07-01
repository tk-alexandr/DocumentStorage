using System.ComponentModel.DataAnnotations;
using System.Web;

namespace DocumentStorage.WebUI.Models
{
    public class DocumentUploadViewModel
    {
        [Required(ErrorMessage="Пожалуйста, укажите название документа")]
        [StringLength(int.MaxValue, MinimumLength = 3, ErrorMessage = "Название должно состоять минимум из 3х букв")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста, загрузите файл."), 
            Microsoft.Web.Mvc.FileExtensions(Extensions = "docx",
            ErrorMessage = "Требуемое расширение файла - docx")]
        public HttpPostedFileBase uploadFile { get; set; }

    }
}