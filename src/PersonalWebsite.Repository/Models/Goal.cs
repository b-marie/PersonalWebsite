using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PersonalWebsite.Repository.Models
{
    public class Goal : Base
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public DateTime? CompletedAt { get; set; }
        public GoalCategory Category { get; set; }
    }
}
