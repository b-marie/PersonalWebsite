using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalWebsite.Logic.Services.Interfaces;
using PersonalWebsite.Repository.Models;

namespace PersonalWebsite.API.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public async Task<List<Admin>> GetAllAdmin()
        {
            return await _adminService.GetAdmin();
        }

        [HttpPost]
        public async Task<Admin> AddAdmin([FromBody] Admin admin)
        {
            return await _adminService.AddAdmin(admin);
        }

        [HttpPut("/{id}")]
        public async Task<Admin> UpdateAdmin([FromBody] Admin admin, [FromQuery] Guid id)
        {
            return await _adminService.UpdateAdmin(admin);
        }

        [HttpGet("/{id}")]
        public async Task<Admin> GetAdminById([FromQuery] Guid id)
        {
            return await _adminService.GetAdminById(id);
        }
        
    }
}