using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SparePartsShop.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }
        [Display(Name = "Имя")]
        [Required(ErrorMessage ="Длинна имени должна быть не менее 5 символов")]
        public string Name { get; set; }
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Длинна фамилии должна быть не менее 5 символов")]
        public string SurName { get; set; }
        [Display(Name = "Адрес")]
        [Required(ErrorMessage = "Длинна адреса должна быть не менее 15 символов")]

        public string Adress { get; set; }
        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Длинна норера должна быть не менее 10 символов")]
        public string Phone { get; set; }
        [Display(Name = "Электронный почтоваый ящик")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Длинна почтового ящика должна быть не менее 10 символов")]
        public string Email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]

        public DateTime OrderTime { get; set; }

        public List<OrderDetails> OrderDetails { get; set; }

    }
}
