using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PersonalWebsite.Repository.Models;

namespace PersonalWebsite.Repository.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllProjects();

        Task<List<Project>> GetProjectsBySkillId(Guid skillId);

        Task<Project> GetProjectById(Guid id);

        Task<Project> AddProject(Project project);

        Task<Project> UpdateProject(Project project);
        Task<Project> DeleteProjectById(Guid id);
    }
}
