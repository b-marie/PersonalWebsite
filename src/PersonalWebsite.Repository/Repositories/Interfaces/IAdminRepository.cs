using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PersonalWebsite.Repository.Models;

namespace PersonalWebsite.Repository.Repositories.Interfaces
{
    public interface IAdminRepository
    {
        Task<Skill> AddSkill(Skill skill);

        Task<Skill> GetSkillById(Guid id);

        Task<ProjectSkills> GetProjectSkillById(Guid id);

        Task<CommunityInvolvementSkills> GetCommunityInvolvementSkillById(Guid id);

        Task<EmploymentSkills> GetEmploymentSkillById(Guid id);

        Task<List<Skill>> GetAllSkills();

        Task<Skill> UpdateSkill(Skill skill);

        Task<Quote> AddQuote(Quote quote);

        Task<Quote> GetQuoteById(Guid id);

        Task<List<Quote>> GetAllQuotes();

        Task<Quote> UpdateQuote(Quote quote);

        Task<Admin> AddAdmin(Admin admin);

        Task<Admin> GetAdminById(Guid id);

        Task<Admin> UpdateAdmin(Admin admin);
    }
}
