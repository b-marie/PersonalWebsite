using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalWebsite.Repository.Models
{
    public class Skill
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<CommunityInvolvementSkills> CommunityInvolvements { get; set; }
        public List<EmploymentSkills> Employments { get; set; }
        public List<ProjectSkills> Projects { get; set; }
    }
}
