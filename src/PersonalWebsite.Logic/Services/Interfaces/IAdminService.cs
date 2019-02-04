using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PersonalWebsite.Repository.Models;

namespace PersonalWebsite.Logic.Services.Interfaces
{
    public interface IAdminService
    {
        Task<List<Admin>> GetAdmin();
        Task<Admin> AddAdmin(Admin admin);
        Task<Admin> GetAdminById(Guid id);
        Task<Admin> UpdateAdmin(Admin admin);
    }
}
