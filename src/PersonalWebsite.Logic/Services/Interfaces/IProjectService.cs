using PersonalWebsite.Repository.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalWebsite.Logic.Services.Interfaces
{
    public interface IProjectService
    {
        Task<Project> AddProject(Project project);

        Task<List<Project>> GetProjects();

        Task<Project> GetProjectById(Guid id);

        Task<Project> UpdateProject(Project project);

        Task<Project> DeleteProjectById(Guid id);

        Task<List<Project>> GetProjectsBySkillId(Guid id);
    }
}
