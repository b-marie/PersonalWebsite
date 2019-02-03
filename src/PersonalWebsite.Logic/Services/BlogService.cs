using System;
using System.Collections.Generic;
using System.Text;
using PersonalWebsite.Logic.Services.Interfaces;
using PersonalWebsite.Repository.Repositories.Interfaces;

namespace PersonalWebsite.Logic.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
    }
}
