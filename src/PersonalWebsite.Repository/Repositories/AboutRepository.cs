using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Repository.Models;
using PersonalWebsite.Repository.Repositories.Interfaces;

namespace PersonalWebsite.Repository.Repositories
{
    public class AboutRepository : IAboutRepository
    {
        private readonly PersonalWebsiteDbContext _context;
        private readonly IAdminRepository _adminRepository;
        public AboutRepository(PersonalWebsiteDbContext context, IAdminRepository adminRepository)
        {
            _context = context;
            _adminRepository = adminRepository;
        }

        public async Task<About> AddAbout(About about)
        {
            await _context.About.AddAsync(about);
            await _context.SaveChangesAsync();
            return about;
        }

        public async Task<About> GetAbout()
        {
            return await _context.About.FirstOrDefaultAsync();
        }

        public async Task<About> UpdateAbout(About about)
        {
            _context.About.Update(about);
            await _context.SaveChangesAsync();
            return about;
        }

        public async Task<CommunityInvolvement> AddCommunityInvolvement(CommunityInvolvement communityInvolvement)
        {
            await _context.CommunityInvolvement.AddAsync(communityInvolvement);
            await _context.SaveChangesAsync();
            return communityInvolvement;
        }

        public async Task<List<CommunityInvolvement>> GetAllCommunityInvolvement()
        {
            return await _context.CommunityInvolvement.ToListAsync();
        }

        public async Task<CommunityInvolvement> GetCommunityInvolvementById(Guid id)
        {
            return await _context.CommunityInvolvement.FindAsync(id);
        }

        public async Task<CommunityInvolvement> DeleteCommunityInvolvementById(Guid id)
        {
            CommunityInvolvement communityInvolvement = await GetCommunityInvolvementById(id);
            _context.CommunityInvolvement.Remove(communityInvolvement);
            await _context.SaveChangesAsync();
            return communityInvolvement;
        }

        public async Task<CommunityInvolvement> UpdateCommunityInvolvment(CommunityInvolvement communityInvolvement)
        {
            _context.CommunityInvolvement.Update(communityInvolvement);
            await _context.SaveChangesAsync();
            return communityInvolvement;
        }

        public async Task<List<CommunityInvolvement>> GetAllCommunityInvolvementBySkill(Guid id)
        {
            CommunityInvolvementSkills skill = await _adminRepository.GetCommunityInvolvementSkillById(id);
            return await _context.CommunityInvolvement.Where(x => x.Skills.Contains(skill)).OrderByDescending(p => p.CreatedAt).ToListAsync();
        }

        public async Task<Book> AddBook(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetBookById(Guid id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<Book> UpdateBook(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> DeleteBookById(Guid id)
        {
            Book book = await GetBookById(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Employment> AddEmployment(Employment employment)
        {
            await _context.Employment.AddAsync(employment);
            await _context.SaveChangesAsync();
            return employment;
        }

        public async Task<List<Employment>> GetAllEmployment()
        {
            return await _context.Employment.ToListAsync();
        }

        public async Task<Employment> GetEmploymentById(Guid id)
        {
            return await _context.Employment.FindAsync(id);
        }

        public async Task<Employment> UpdateEmployment(Employment employment)
        {
            _context.Employment.Update(employment);
            await _context.SaveChangesAsync();
            return employment;
        }

        public async Task<Employment> DeleteEmploymentById(Guid id)
        {
            Employment employment = await GetEmploymentById(id);
            _context.Employment.Remove(employment);
            await _context.SaveChangesAsync();
            return employment;
        }

        public async Task<List<Employment>> GetAllEmploymentBySkillId(Guid id)
        {
            EmploymentSkills skill = await _adminRepository.GetEmploymentSkillById(id);
            return await _context.Employment.Where(x => x.Skills.Contains(skill)).OrderByDescending(p => p.CreatedAt).ToListAsync();
        }

        public async Task<GoalCategory> AddGoalCategory(GoalCategory category)
        {
            await _context.GoalCategories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<List<GoalCategory>> GetAllGoalCategories()
        {
            return await _context.GoalCategories.ToListAsync();
        }

        public async Task<GoalCategory> GetGoalCategoryById(Guid id)
        {
            return await _context.GoalCategories.FindAsync(id);
        }

        public async Task<GoalCategory> UpdateGoalCategory(GoalCategory category)
        {
            _context.GoalCategories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<GoalCategory> DeleteGoalCategoryById(Guid id)
        {
            GoalCategory categoryToDelete = await GetGoalCategoryById(id);
            _context.GoalCategories.Remove(categoryToDelete);
            await _context.SaveChangesAsync();
            return categoryToDelete;
        }

        public async Task<Goal> AddGoal(Goal goal)
        {
            await _context.Goals.AddAsync(goal);
            await _context.SaveChangesAsync();
            return goal;
        }

        public async Task<List<Goal>> GetAllGoals()
        {
            return await _context.Goals.ToListAsync();
        }

        public async Task<Goal> GetGoalById(Guid id)
        {
            return await _context.Goals.FindAsync(id);
        }

        public async Task<Goal> UpdateGoal(Goal goal)
        {
            _context.Goals.Update(goal);
            await _context.SaveChangesAsync();
            return goal;
        }

        public async Task<Goal> DeleteGoalById(Guid id)
        {
            Goal goalToDelete = await GetGoalById(id);
            _context.Goals.Remove(goalToDelete);
            await _context.SaveChangesAsync();
            return goalToDelete;
        }

        public async Task<List<Goal>> GetGoalsByCategoryId(Guid id)
        {
            GoalCategory category = await GetGoalCategoryById(id);
            return await _context.Goals.Where(x => x.Category == category).ToListAsync();
        }

        public async Task<List<Goal>> GetAllActiveGoals()
        {
            return await _context.Goals.Where(x => x.Active == true).ToListAsync();
        }

        public async Task<List<Goal>> GetAllCompletedGoals()
        {
            return await _context.Goals.Where(x => x.Active == false).ToListAsync();
        }

        public async Task<Interest> AddInterest(Interest interest)
        {
            await _context.Interests.AddAsync(interest);
            await _context.SaveChangesAsync();
            return interest;
        }

        public async Task<List<Interest>> GetAllInterests()
        {
            return await _context.Interests.ToListAsync();
        }

        public async Task<Interest> GetInterestById(Guid id)
        {
            return await _context.Interests.FindAsync(id);
        }

        public async Task<Interest> UpdateInterest(Interest interest)
        {
            _context.Interests.Update(interest);
            await _context.SaveChangesAsync();
            return interest;
        }

        public async Task<Interest> RemoveInterestById(Guid id)
        {
            Interest interest = await GetInterestById(id);
            _context.Interests.Remove(interest);
            await _context.SaveChangesAsync();
            return interest;
        }

    }
}
