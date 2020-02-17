using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SyncaBlog.Models
{
    public class CommentAddModel
    {
        public int PostId { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите сообщение")]
        [StringLength(300, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 300 символов")]
        public string Description { get; set; }
    }
}