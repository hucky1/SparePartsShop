using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SparePartsShop.Models
{
    public class Reviews
    {
        public int Id { get; set; }

        [Display(Name ="Ваше имя")] public string UserName { get; set; }
        [Display(Name = "Отзыв")] public string Text { get; set; }
       
    }
}
