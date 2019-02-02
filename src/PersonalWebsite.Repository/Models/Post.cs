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
        [ForeignKey("PostCategories")]
        public Guid Category { get; set; }
        [ForeignKey("PostTags")]
        public virtual List<Guid> Tags { get; set; }
    }
}
