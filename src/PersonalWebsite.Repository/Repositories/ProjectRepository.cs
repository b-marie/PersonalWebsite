using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Repository.Models;
using PersonalWebsite.Repository.Repositories.Interfaces;

namespace PersonalWebsite.Repository.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly PersonalWebsiteDbContext _context;
        private readonly IAdminRepository _adminRepository;
        public ProjectRepository(PersonalWebsiteDbContext context, IAdminRepository adminRepository)
        {
            _context = context;
            _adminRepository = adminRepository;
        }
        public async Task<List<Project>> GetAllProjects()
        {
            return await _context.Projects.OrderByDescending(x => x.CreatedAt).ToListAsync();
        }

        public async Task<List<Project>> GetProjectsBySkillId(Guid skillId)
        {
            ProjectSkills skill = await _adminRepository.GetProjectSkillById(skillId);
            return await _context.Projects.Where(x => x.SkillsUsed.Contains(skill)).OrderByDescending(p => p.CreatedAt).ToListAsync();
        }

        public async Task<Project> GetProjectById(Guid id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public async Task<Project> AddProject(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<Project> UpdateProject(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<Project> DeleteProjectById(Guid id)
        {
            Project project = await GetProjectById(id);
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return project;
        }
    }
}
