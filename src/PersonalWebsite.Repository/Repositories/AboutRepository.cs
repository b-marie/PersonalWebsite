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
        private readonly AdminRepository _adminRepository;
        public AboutRepository(PersonalWebsiteDbContext context, AdminRepository adminRepository)
        {
            _context = context;
            _adminRepository = adminRepository;
        }

        public async Task<About> AddAbout(About about)
        {
            about.CreatedAt = DateTime.UtcNow;
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
            About aboutToUpdate = await GetAbout();
            aboutToUpdate.Description = about.Description;
            aboutToUpdate.ImageUrl = about.ImageUrl;
            aboutToUpdate.LastUpdatedAt = DateTime.UtcNow;
            _context.About.Update(aboutToUpdate);
            await _context.SaveChangesAsync();
            return aboutToUpdate;
        }

        public async Task<CommunityInvolvement> AddCommunityInvolvement(CommunityInvolvement communityInvolvement)
        {
            communityInvolvement.CreatedAt = DateTime.UtcNow;
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
            CommunityInvolvement communityInvolvementToUpdate =
                await GetCommunityInvolvementById(communityInvolvement.Id);
            communityInvolvementToUpdate.Title = communityInvolvement.Title;
            communityInvolvementToUpdate.StartDate = communityInvolvement.StartDate;
            communityInvolvementToUpdate.Description = communityInvolvement.Description;
            communityInvolvementToUpdate.EndDate = communityInvolvement.EndDate;
            communityInvolvementToUpdate.Url = communityInvolvement.Url;
            communityInvolvementToUpdate.ImageUrl = communityInvolvement.ImageUrl;
            communityInvolvementToUpdate.Skills = communityInvolvementToUpdate.Skills;
            communityInvolvementToUpdate.LastUpdatedAt = DateTime.UtcNow;
            _context.CommunityInvolvement.Update(communityInvolvementToUpdate);
            await _context.SaveChangesAsync();
            return communityInvolvementToUpdate;
        }

        public async Task<List<CommunityInvolvement>> GetAllCommunityInvolvementBySkill(Guid id)
        {
            CommunityInvolvementSkills skill = await _adminRepository.GetCommunityInvolvementSkillById(id);
            return await _context.CommunityInvolvement.Where(x => x.Skills.Contains(skill)).OrderByDescending(p => p.CreatedAt).ToListAsync();
        }

        public async Task<Book> AddBook(Book book)
        {
            book.CreatedAt = DateTime.UtcNow;
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
            Book bookToUpdate = await GetBookById(book.Id);
            bookToUpdate.Author = book.Author;
            bookToUpdate.Description = book.Description;
            bookToUpdate.FinishedReadingAt = book.FinishedReadingAt;
            bookToUpdate.ImageUrl = book.ImageUrl;
            bookToUpdate.Rating = book.Rating;
            bookToUpdate.Recommendation = book.Recommendation;
            bookToUpdate.Title = book.Title;
            bookToUpdate.Url = book.Url;
            bookToUpdate.LastUpdatedAt = DateTime.UtcNow;
            _context.Books.Update(bookToUpdate);
            await _context.SaveChangesAsync();
            return bookToUpdate;
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
            employment.CreatedAt = DateTime.UtcNow;
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
            Employment employmentToUpdate = await GetEmploymentById(employment.Id);
            employmentToUpdate.Skills = employment.Skills;
            employmentToUpdate.CompanyLogoUrl = employment.CompanyLogoUrl;
            employmentToUpdate.CompanyName = employment.CompanyName;
            employmentToUpdate.CompanyUrl = employment.CompanyUrl;
            employmentToUpdate.EndDate = employment.EndDate;
            employmentToUpdate.JobDescription = employment.JobDescription;
            employmentToUpdate.JobTitle = employment.JobTitle;
            employmentToUpdate.StartDate = employment.StartDate;
            employmentToUpdate.LastUpdatedAt = DateTime.UtcNow;
            _context.Employment.Update(employmentToUpdate);
            await _context.SaveChangesAsync();
            return employmentToUpdate;
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
            GoalCategory categoryToUpdate = await GetGoalCategoryById(category.Id);
            categoryToUpdate.Name = category.Name;
            categoryToUpdate.Goals = category.Goals;
            _context.GoalCategories.Update(categoryToUpdate);
            await _context.SaveChangesAsync();
            return categoryToUpdate;
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
            goal.Active = true;
            goal.CreatedAt = DateTime.UtcNow;
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
            Goal goalToUpdate = await GetGoalById(goal.Id);
            goalToUpdate.Category = goal.Category;
            goalToUpdate.Active = goal.Active;
            goalToUpdate.CompletedAt = goal.CompletedAt;
            goalToUpdate.Description = goal.Description;
            goalToUpdate.Title = goal.Title;
            goalToUpdate.LastUpdatedAt = DateTime.UtcNow;
            _context.Goals.Update(goalToUpdate);
            await _context.SaveChangesAsync();
            return goalToUpdate;
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

        public async Task<Goal> CompleteGoalById(Guid id)
        {
            Goal goalToComplete = await GetGoalById(id);
            goalToComplete.Active = false;
            if (goalToComplete.CompletedAt == null)
            {
                goalToComplete.CompletedAt = DateTime.UtcNow;
            }
            return await UpdateGoal(goalToComplete);
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
            interest.CreatedAt = DateTime.UtcNow;
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
            Interest interestToUpdate = await GetInterestById(interest.Id);
            interestToUpdate.Description = interest.Description;
            interestToUpdate.Title = interest.Title;
            interestToUpdate.ImageUrl = interest.ImageUrl;
            interestToUpdate.LastUpdatedAt = DateTime.UtcNow;
            _context.Interests.Update(interestToUpdate);
            await _context.SaveChangesAsync();
            return interestToUpdate;
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
