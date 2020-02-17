using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using SyncaBlog.Core.Models;

namespace SyncaBlog.Core.Models
{
    public class User
    {
     
        public int Id { get; set; }
        [Display(Name = "Логин")]
        public string Email { get; set; }
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        [Display(Name = "Роль")]
        public int RoleId { get; set; }
        public Role Role { get; set; }
       public   Blog MyBlog { get; set; }
        public int BlogId { get; set; }

    }
}
