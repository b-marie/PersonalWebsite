using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalWebsite.Repository.Models
{
    public class Book : Base
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }
        public int? Rating { get; set; }
        public string Recommendation { get; set; }
        public DateTime? FinishedReadingAt { get; set; }
    }
}
