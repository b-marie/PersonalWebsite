using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace PersonalWebsite.Repository.Models
{
    public class PostCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Post> Posts { get; set; }
    }
}
