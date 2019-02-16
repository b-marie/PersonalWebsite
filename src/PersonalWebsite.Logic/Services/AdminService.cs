using PersonalWebsite.Logic.Services.Interfaces;
using PersonalWebsite.Repository.Models;
using PersonalWebsite.Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalWebsite.Logic.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<List<Admin>> GetAdmin()
        {
            return await _adminRepository.GetAdmin();
        }

        public async Task<Admin> AddAdmin(Admin admin)
        {
            admin.Id = Guid.NewGuid();
            admin.CreatedAt = DateTime.UtcNow;
            return await _adminRepository.AddAdmin(admin);
        }

        public async Task<Admin> GetAdminById(Guid id)
        {
            return await _adminRepository.GetAdminById(id);
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
            return await _adminRepository.UpdateAdmin(adminToUpdate);
        }
    }
}
