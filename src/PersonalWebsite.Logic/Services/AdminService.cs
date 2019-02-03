using System;
using System.Collections.Generic;
using System.Text;
using PersonalWebsite.Logic.Services.Interfaces;
using PersonalWebsite.Repository.Repositories.Interfaces;

namespace PersonalWebsite.Logic.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
    }
}
