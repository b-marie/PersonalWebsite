using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Repository.Models;

namespace PersonalWebsite.Repository.Repositories
{
    public class ProjectRepository
    {
        private readonly PersonalWebsiteDbContext _context;
        private readonly AdminRepository _adminRepository;
        public ProjectRepository(PersonalWebsiteDbContext context, AdminRepository adminRepository)
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
            project.CreatedAt = DateTime.UtcNow;
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<Project> UpdateProject(Project project)
        {
            Project projectToUpdate = await GetProjectById(project.Id);
            projectToUpdate.Title = project.Title;
            projectToUpdate.Description = project.Description;
            projectToUpdate.ImageUrl = project.ImageUrl;
            projectToUpdate.ProjectUrl = project.ProjectUrl;
            projectToUpdate.GitHubUrl = project.GitHubUrl;
            projectToUpdate.SkillsUsed = project.SkillsUsed;
            projectToUpdate.LastUpdatedAt = DateTime.UtcNow;
            _context.Projects.Update(projectToUpdate);
            await _context.SaveChangesAsync();
            return projectToUpdate;
        }
    }
}
