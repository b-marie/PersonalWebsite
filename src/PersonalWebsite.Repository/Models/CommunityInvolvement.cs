using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PersonalWebsite.Repository.Models
{
    public class CommunityInvolvement : Base
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public virtual List<CommunityInvolvementSkills> Skills { get; set; }
    }
}
