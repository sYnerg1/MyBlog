using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SyncaBlog.Core.Models;
using SyncaBlog.Infrastructure;

namespace SyncaBlog.Models
{
    public class TagDetailViewModel
    {
        public int TagId { get; set; }
        public string TagName{ get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public NumericPagingInfo Paging { get; set; }
    }
}