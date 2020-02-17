﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SyncaBlog.Infrastructure
{
    public class NumericPagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int SelectedPageNumber { get; set; }
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
        }
    }
}