using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Repository.Models;

namespace PersonalWebsite.Repository
{
    public class PersonalWebsiteDbContext : DbContext
    {
        internal DbSet<About> About { get; set; }
        internal DbSet<Book> Books { get; set; }
        internal DbSet<CommunityInvolvement> CommunityInvolvement { get; set; }
        internal DbSet<Employment> Employment { get; set; }
        internal DbSet<Goal> Goals { get; set; }
        internal DbSet<GoalCategory> GoalCategories { get; set; }
        internal DbSet<Interest> Interests { get; set; }
        internal DbSet<Post> Posts { get; set; }
        internal DbSet<PostCategory> PostCategories { get; set; }
        internal DbSet<Tag> Tags { get; set; }
        internal DbSet<Project> Projects { get; set; }
        internal DbSet<Quote> Quotes { get; set; }
        internal DbSet<Skill> Skills { get; set; }
        internal DbSet<ProjectSkills> ProjectSkills { get; set; }
        internal DbSet<CommunityInvolvementSkills> CommunityInvolvementSkills { get; set; }
        internal DbSet<EmploymentSkills> EmploymentSkills { get; set; }
        internal DbSet<PostTag> PostTag { get; set; }


        public PersonalWebsiteDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure Community Involvement Skills
            modelBuilder.Entity<CommunityInvolvementSkills>().HasKey(k => new {k.CommunityInvolvementId, k.SkillId});
            modelBuilder.Entity<CommunityInvolvementSkills>().HasOne(s => s.Skill)
                .WithMany(c => c.CommunityInvolvements).HasForeignKey(k => k.CommunityInvolvementId);
            modelBuilder.Entity<CommunityInvolvementSkills>().HasOne(c => c.CommunityInvolvement)
                .WithMany(s => s.Skills).HasForeignKey(k => k.SkillId);

            //Configure Employment Skills
            modelBuilder.Entity<EmploymentSkills>().HasKey(k => new {k.EmploymentId, k.SkillId});
            modelBuilder.Entity<EmploymentSkills>().HasOne(s => s.Skill).WithMany(e => e.Employments)
                .HasForeignKey(k => k.EmploymentId);
            modelBuilder.Entity<EmploymentSkills>().HasOne(e => e.Employment).WithMany(s => s.Skills)
                .HasForeignKey(k => k.SkillId);

            //Configure Project Skills
            modelBuilder.Entity<ProjectSkills>().HasKey(k => new {k.ProjectId, k.SkillId});
            modelBuilder.Entity<ProjectSkills>().HasOne(s => s.Skill).WithMany(p => p.Projects)
                .HasForeignKey(k => k.ProjectId);
            modelBuilder.Entity<ProjectSkills>().HasOne(p => p.Project).WithMany(s => s.SkillsUsed)
                .HasForeignKey(k => k.SkillId);

            //Configure Post Tags
            modelBuilder.Entity<PostTag>().HasKey(t => new {t.PostId, t.TagId});
            modelBuilder.Entity<PostTag>().HasOne(pt => pt.Post).WithMany(p => p.Tags).HasForeignKey(pt => pt.PostId);
            modelBuilder.Entity<PostTag>().HasOne(pt => pt.Tag).WithMany(t => t.PostTags).HasForeignKey(pt => pt.TagId);

            //Configure Post Category
            modelBuilder.Entity<Post>().Property<Guid>("PostCategoryForeignKey");
            modelBuilder.Entity<Post>().HasOne(p => p.Category).WithMany(c => c.Posts)
                .HasForeignKey("PostCategoryForeignKey");

            //Configure Goal Category
            modelBuilder.Entity<Goal>().Property<Guid>("GoalCategoryForeignKey");
            modelBuilder.Entity<Goal>().HasOne(c => c.Category).WithMany(g => g.Goals)
                .HasForeignKey("GoalCategoryForeignKey");
        }
    }
}
