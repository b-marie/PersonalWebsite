using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalWebsite.Repository.Models
{
    public class Quote
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
    }
}
