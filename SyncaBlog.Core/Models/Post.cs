using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SyncaBlog.Core.Models
{
   public class Post
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Пожалуйста, укажите название для статьи")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Пожалуйста, укажите текст статьи")]
        [StringLength(5000, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 5000 символов")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        [Required(ErrorMessage = "Пожалуйста, укажите короткое описание статьи")]
        [StringLength(450, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 450 символов")]
        [DataType(DataType.MultilineText)]
        public string ShortText { get; set; }
        public DateTime CreationTime { get; set; }
        public Blog MyBlog { get; set; }
        public int BlogId { get; set; }
        public List<Tag> MyTag { get; set; }
        public List<Comment> MyComment { get; set; }
        public Post()
        {
            MyTag = new List<Tag>();
            MyComment = new List<Comment>();
        }
    }
}
