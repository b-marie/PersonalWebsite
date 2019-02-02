using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalWebsite.Repository.Models
{
    public class EmploymentSkills
    {
        public Guid EmploymentId { get; set; }
        public Employment Employment { get; set; }

        public Guid SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
