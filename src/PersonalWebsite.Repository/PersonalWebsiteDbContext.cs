using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Repository.Models;

namespace PersonalWebsite.Repository
{
    public class PersonalWebsiteDbContext : DbContext
    {
        private DbSet<About> About { get; set; }
        private DbSet<Book> Books { get; set; }
        private DbSet<CommunityInvolvement> CommunityInvolvement { get; set; }
        private DbSet<Employment> Employment { get; set; }
        private DbSet<Goal> Goals { get; set; }
        private DbSet<GoalCategory> GoalCategories { get; set; }
        private DbSet<Interest> Interests { get; set; }
        private DbSet<Post> Posts { get; set; }
        private DbSet<PostCategory> PostCategories { get; set; }
        private DbSet<PostTag> PostTags { get; set; }
        private DbSet<Project> Projects { get; set; }
        public DbSet<Skill> Skills { get; set; }


        public PersonalWebsiteDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
