using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Core.Model
{
    public class BlogCriteria
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }
    }
}
