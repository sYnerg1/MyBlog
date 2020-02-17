using SyncaBlog.Core.Models;
using SyncaBlog.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SyncaBlog.Models
{
    public class CommentViewModel
    {
        public IEnumerable<Comment> Comments { get; set; }
        public NumericPagingInfo Paging { get; set; }
        public int PostId { get; set; }       
    }
}