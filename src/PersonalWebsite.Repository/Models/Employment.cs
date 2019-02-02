using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PersonalWebsite.Repository.Models
{
    public class Employment : Base
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLogoUrl { get; set; }
        public string CompanyUrl { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [ForeignKey("Skills")]
        public virtual List<Guid> Skills { get; set; }
    }
}
