using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Repository.Models;

namespace PersonalWebsite.Repository.Repositories
{
    public class BlogRepository
    {
        private readonly PersonalWebsiteDbContext _context;

        public BlogRepository(PersonalWebsiteDbContext context)
        {
            _context = context;
        }

        public async Task<List<Post>> GetAllPosts()
        {
            return await _context.Posts.ToListAsync();
        }
    }
}
