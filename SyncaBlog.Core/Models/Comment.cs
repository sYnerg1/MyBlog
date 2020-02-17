using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncaBlog.Core.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите сообщение")]
        [StringLength(300, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Display(Name = "Текст комментария")]
        public string Description { get; set; }
        public Post MyPost { get; set; }
        public int PostId { get; set; }
    }
}
