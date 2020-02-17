using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SyncaBlog.Models.AccountViewModels
{
    public class RegisterModel
    {

        [Required(ErrorMessage = "Пожалуйста, укажите логин")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Длина строки должна быть от 4 до 30 символов")]
        [Display(Name = "Логин")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Длина строки должна быть от 4 до 30 символов")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [Display(Name = "Повторите пароль")]
        public string ConfirmPassword { get; set; }
    }
}