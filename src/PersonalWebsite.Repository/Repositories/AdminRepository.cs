using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Repository.Models;
using PersonalWebsite.Repository.Repositories.Interfaces;

namespace PersonalWebsite.Repository.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly PersonalWebsiteDbContext _context;
        public AdminRepository(PersonalWebsiteDbContext context)
        {
            _context = context;
        }
        public async Task<Skill> AddSkill(Skill skill)
        {
            await _context.Skills.AddAsync(skill);
            await _context.SaveChangesAsync();
            return skill;
        }

        public async Task<Skill> GetSkillById(Guid id)
        {
            return await _context.Skills.FindAsync(id);
        }

        public async Task<ProjectSkills> GetProjectSkillById(Guid id)
        {
            return await _context.ProjectSkills.Where(x => x.SkillId == id).FirstOrDefaultAsync();
        }

        public async Task<CommunityInvolvementSkills> GetCommunityInvolvementSkillById(Guid id)
        {
            return await _context.CommunityInvolvementSkills.Where(x => x.SkillId == id).FirstOrDefaultAsync();
        }

        public async Task<EmploymentSkills> GetEmploymentSkillById(Guid id)
        {
            return await _context.EmploymentSkills.Where(x => x.SkillId == id).FirstOrDefaultAsync();
        }

        public async Task<List<Skill>> GetAllSkills()
        {
            return await _context.Skills.ToListAsync();
        }
        public async Task<Skill> UpdateSkill(Skill skill)
        {
            Skill skillToUpdate = await GetSkillById(skill.Id);
            skillToUpdate.Name = skill.Name;
            _context.Skills.Update(skillToUpdate);
            await _context.SaveChangesAsync();
            return skillToUpdate;
        }

        public async Task<Quote> AddQuote(Quote quote)
        {
            await _context.Quotes.AddAsync(quote);
            await _context.SaveChangesAsync();
            return quote;
        }

        public async Task<Quote> GetQuoteById(Guid id)
        {
            return await _context.Quotes.FindAsync(id);
        }

        public async Task<List<Quote>> GetAllQuotes()
        {
            return await _context.Quotes.ToListAsync();
        }

        public async Task<Quote> UpdateQuote(Quote quote)
        {
            Quote quoteToUpdate = await GetQuoteById(quote.Id);
            quoteToUpdate.Author = quote.Author;
            quoteToUpdate.Text = quote.Text;
            _context.Quotes.Update(quoteToUpdate);
            await _context.SaveChangesAsync();
            return quoteToUpdate;
        }

        public async Task<Admin> AddAdmin(Admin admin)
        {
            admin.CreatedAt = DateTime.UtcNow;
            await _context.Admin.AddAsync(admin);
            await _context.SaveChangesAsync();
            return admin;
        }

        public async Task<Admin> GetAdminById(Guid id)
        {
            return await _context.Admin.FindAsync(id);
        }

        public async Task<Admin> UpdateAdmin(Admin admin)
        {
            Admin adminToUpdate = await GetAdminById(admin.Id);
            adminToUpdate.FirstName = admin.FirstName;
            adminToUpdate.LastName = admin.LastName;
            adminToUpdate.EmailAddress = admin.EmailAddress;
            adminToUpdate.LinkedInUrl = admin.LinkedInUrl;
            adminToUpdate.GitHubUrl = admin.GitHubUrl;
            adminToUpdate.LastUpdatedAt = DateTime.UtcNow;
            _context.Admin.Update(adminToUpdate);
            await _context.SaveChangesAsync();
            return adminToUpdate;
        }
    }
}
