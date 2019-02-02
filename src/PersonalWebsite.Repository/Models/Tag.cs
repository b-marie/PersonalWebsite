using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalWebsite.Repository.Models
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<PostTag> PostTags { get; set; }
    }
}
