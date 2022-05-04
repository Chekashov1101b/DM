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
        [StringLength(45, MinimumLength = 3)]
        public string Name { get; set; }
        [Display(Name = "Век")]
        [Range(1, Int32.MaxValue)]
        public int Century { get; set; }
        [Display(Name = "Нашей эры?")]
        public bool Era { get; set; }
        [Display(Name = "Место хранения")]
        [StringLength(45, MinimumLength = 3)]
        public string Place { get; set; }
        [Display(Name = "Стоимость")]
        [DataType(DataType.Currency)]
        [Range(0, Int32.MaxValue)]
        public int Cost { get; set; }
        [Display(Name = "Краткое описание")]
        [StringLength(120, MinimumLength = 10)]
        public string Discription { get; set; }
        [Display(Name = "Изображение")]
        public byte[] Image { get; set; }
    }
}
