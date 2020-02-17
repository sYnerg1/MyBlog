using SyncaBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SyncaBlog.Models
{
    public class PostEditModel
    {
        //[Key]
        public int Id { get; set; }
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
        [Required(ErrorMessage = "Пожалуйста, укажите краткое описание статьи")]
        [StringLength(450, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 450 символов")]
        [DataType(DataType.MultilineText)]
        public string ShortText { get; set; }
        // public Post Post { get; set; }
        public List<string> TagSelected { get; set; }
        public MultiSelectList Tags { get; set; }
        public int BlogId { get; set; }
        public DateTime CreationTime { get; set; }
    }
}