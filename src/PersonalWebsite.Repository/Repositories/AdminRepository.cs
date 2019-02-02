using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Repository.Models;

namespace PersonalWebsite.Repository.Repositories
{
    public class AdminRepository
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
    }
}
