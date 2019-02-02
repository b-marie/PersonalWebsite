using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalWebsite.Repository.Models
{
    public class CommunityInvolvementSkills
    {
        public Guid CommunityInvolvementId { get; set; }
        public CommunityInvolvement CommunityInvolvement { get; set; }


        public Guid SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
