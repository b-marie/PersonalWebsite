using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PersonalWebsite.Repository.Models
{
    public class Project : Base
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string ProjectUrl { get; set; }
        public string GitHubUrl { get; set; }
        [ForeignKey("Skills")]
        public virtual List<Guid> SkillsUsed { get; set; }
    }
}
