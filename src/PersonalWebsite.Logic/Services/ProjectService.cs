using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PersonalWebsite.Logic.Services.Interfaces;
using PersonalWebsite.Repository.Models;
using PersonalWebsite.Repository.Repositories;
using PersonalWebsite.Repository.Repositories.Interfaces;

namespace PersonalWebsite.Logic.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Project> AddProject(Project project)
        {
            project.Id = Guid.NewGuid();
            project.CreatedAt = DateTime.UtcNow;
            return await _projectRepository.AddProject(project);
        }

        public async Task<List<Project>> GetProjects()
        {
            return await _projectRepository.GetAllProjects();
        }

        public async Task<Project> GetProjectById(Guid id)
        {
            return await _projectRepository.GetProjectById(id);
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
            return await _projectRepository.UpdateProject(projectToUpdate);
        }

        public async Task<Project> DeleteProjectById(Guid id)
        {
            return await _projectRepository.DeleteProjectById(id);
        }

        public async Task<List<Project>> GetProjectsBySkillId(Guid id)
        {
            return await _projectRepository.GetProjectsBySkillId(id);
        }
    }
}
