using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Core.Model
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public DateTime? DatePosted { get; set; }
    }
}
