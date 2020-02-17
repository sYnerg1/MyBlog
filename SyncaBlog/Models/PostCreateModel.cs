using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SyncaBlog.Core.Models;

namespace SyncaBlog.Models
{
    public class PostCreateModel
    {
        [Display(Name = "Текст статьи")]
        [Required(ErrorMessage = "Пожалуйста, укажите текст статьи")]
        [StringLength(5000, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 5000 символов")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        [Display(Name = "Заголовок")]
        [Required(ErrorMessage = "Пожалуйста, укажите название для статьи")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Title { get; set; }
        [Display(Name = "Краткое описание")]
        [Required(ErrorMessage = "Пожалуйста, укажите короткое описание статьи")]
        [StringLength(450, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 450 символов")]
        [DataType(DataType.MultilineText)]
        public string ShortText { get; set; }
        public List<string> TagIds { get; set; }
        public MultiSelectList Tags { get; set; }
    }
}