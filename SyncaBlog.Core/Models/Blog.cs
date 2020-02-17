using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace SyncaBlog.Core.Models
{
    public class Blog
    { 
        public int Id { get; set; }
        [Required(ErrorMessage = "Пожалуйста, укажите название вашего блога")]
        [Display(Name = "Название блога")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Пожалуйста, укажите короткое описание для блога")]
        [Display(Name = "Описание блога")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 500 символов")]
        public string Description { get; set; }
        public List<Post> MyPost { get; set; }           
        public Blog()
        {
            MyPost = new List<Post>();
        }

    }
}
