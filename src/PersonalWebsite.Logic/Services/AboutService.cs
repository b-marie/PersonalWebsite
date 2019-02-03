using System;
using System.Collections.Generic;
using System.Text;
using PersonalWebsite.Logic.Services.Interfaces;
using PersonalWebsite.Repository.Repositories.Interfaces;

namespace PersonalWebsite.Logic.Services
{
    public class AboutService : IAboutService
    {
        private readonly IAboutRepository _aboutRepository;
        public AboutService(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }
    }
}
