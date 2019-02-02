using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalWebsite.Repository.Models
{
    public class Interest : Base
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
