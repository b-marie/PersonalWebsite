using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text;

namespace PersonalWebsite.Repository.Models
{
    public class Post : Base
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImageLink { get; set; }
        public bool Published { get; set; }
        public DateTime? LastSavedAt { get; set; }
        public DateTime? PublishedAt { get; set; }
        public PostCategory Category { get; set; }
        public virtual List<PostTag> Tags { get; set; }
    }
}
