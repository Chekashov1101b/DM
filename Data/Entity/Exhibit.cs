using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DM.Data.Entity
{
    public class Exhibit
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
        public byte[] Image { get; set; }
    }
}
