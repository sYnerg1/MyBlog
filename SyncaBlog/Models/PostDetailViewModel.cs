using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SyncaBlog.Core.Models;

namespace SyncaBlog.Models
{
    public class PostDetailViewModel
    {
        public CommentViewModel Comment { get; set; }
        public Post Post { get; set; }
        
    }
}