using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DM.Models
{
    public class ExhibitViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Название экспоната")]
        public string Name { get; set; }
        [Display(Name = "Век")]
        public int Century { get; set; }
        [Display(Name = "Нашей эры?")]
        public bool Era { get; set; }
        [Display(Name = "Место хранения")]
        public string Place { get; set; }
        [Display(Name = "Стоимость")]
        [DataType(DataType.Currency)]
        public int Cost { get; set; }
        [Display(Name = "Краткое описание")]
        public string Discription { get; set; }
        [Display(Name = "Изображение")]
        public IFormFile upload { get; set; }
        public byte[] Image { get; set; }
    }
}
