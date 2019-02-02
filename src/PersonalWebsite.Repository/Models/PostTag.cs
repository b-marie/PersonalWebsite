using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace PersonalWebsite.Repository.Models
{
    public class PostTag
    {
        public Guid PostId { get; set; }
        public Post Post { get; set; }

        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
