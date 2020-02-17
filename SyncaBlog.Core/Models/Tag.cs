using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncaBlog.Core.Models
{
   public class Tag
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Пожалуйста, ")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 030 символов")]
        [Display(Name = "Тэг")]
        public string Name { get; set; }
        public List<Post> MyPost { get; set; }
        public Tag()
        {
            MyPost = new List<Post>();
        }
    }
}
