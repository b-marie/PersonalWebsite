using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Repository.Models;

namespace PersonalWebsite.Repository.Repositories
{
    public class ProjectRepository
    {
        private readonly PersonalWebsiteDbContext _context;
        public ProjectRepository(PersonalWebsiteDbContext context)
        {
            _context = context;
        }
        public async Task<List<Project>> GetAllProjects()
        {
            return await _context.Projects.OrderByDescending(x => x.CreatedAt).ToListAsync();
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
