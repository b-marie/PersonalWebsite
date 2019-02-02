using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalWebsite.Repository.Models
{
    public class ProjectSkills
    {
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        public Guid SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
