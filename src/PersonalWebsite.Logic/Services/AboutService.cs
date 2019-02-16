using PersonalWebsite.Logic.Services.Interfaces;
using PersonalWebsite.Repository.Models;
using PersonalWebsite.Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalWebsite.Logic.Services
{
    public class AboutService : IAboutService
    {
        private readonly IAboutRepository _aboutRepository;

        public AboutService(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public async Task<About> AddAbout(About about)
        {
            about.CreatedAt = DateTime.UtcNow;
            return await _aboutRepository.AddAbout(about);
        }

        public async Task<About> GetAbout()
        {
            return await _aboutRepository.GetAbout();
        }

        public async Task<About> UpdateAbout(About about)
        {
            About aboutToUpdate = await GetAbout();
            aboutToUpdate.Description = about.Description;
            aboutToUpdate.ImageUrl = about.ImageUrl;
            aboutToUpdate.LastUpdatedAt = DateTime.UtcNow;
            return await _aboutRepository.UpdateAbout(aboutToUpdate);
        }

        public async Task<CommunityInvolvement> AddCommunityInvolvement(CommunityInvolvement communityInvolvement)
        {
            communityInvolvement.CreatedAt = DateTime.UtcNow;
            return await _aboutRepository.AddCommunityInvolvement(communityInvolvement);
        }

        public async Task<List<CommunityInvolvement>> GetAllCommunityInvolvement()
        {
            return await _aboutRepository.GetAllCommunityInvolvement();
        }

        public async Task<CommunityInvolvement> GetCommunityInvolvementById(Guid id)
        {
            return await _aboutRepository.GetCommunityInvolvementById(id);
        }

        public async Task<CommunityInvolvement> DeleteCommunityInvolvementById(Guid id)
        {
            return await _aboutRepository.DeleteCommunityInvolvementById(id);
        }

        public async Task<CommunityInvolvement> UpdateCommunityInvolvement(CommunityInvolvement communityInvolvement)
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
            return await _aboutRepository.UpdateCommunityInvolvment(communityInvolvementToUpdate);
        }

        public async Task<List<CommunityInvolvement>> GetAllCommunityInvolvementBySkill(Guid id)
        {
            return await _aboutRepository.GetAllCommunityInvolvementBySkill(id);
        }

        public async Task<Book> AddBook(Book book)
        {
            book.CreatedAt = DateTime.UtcNow;
            return await _aboutRepository.AddBook(book);
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _aboutRepository.GetAllBooks();
        }

        public async Task<Book> GetBookById(Guid id)
        {
            return await _aboutRepository.GetBookById(id);
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
            return await _aboutRepository.UpdateBook(book);
        }

        public async Task<Book> DeleteBookById(Guid id)
        {
            return await _aboutRepository.DeleteBookById(id);
        }

        public async Task<Employment> AddEmployment(Employment employment)
        {
            employment.CreatedAt = DateTime.UtcNow;
            return await _aboutRepository.AddEmployment(employment);
        }

        public async Task<List<Employment>> GetAllEmployment()
        {
            return await _aboutRepository.GetAllEmployment();
        }

        public async Task<Employment> GetEmploymentById(Guid id)
        {
            return await _aboutRepository.GetEmploymentById(id);
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
            return await _aboutRepository.UpdateEmployment(employmentToUpdate);
        }

        public async Task<Employment> DeleteEmploymentById(Guid id)
        {
            return await _aboutRepository.DeleteEmploymentById(id);
        }

        public async Task<List<Employment>> GetAllEmploymentBySkillId(Guid id)
        {
            return await _aboutRepository.GetAllEmploymentBySkillId(id);
        }

        public async Task<GoalCategory> AddGoalCategory(GoalCategory category)
        {
            return await _aboutRepository.AddGoalCategory(category);
        }

        public async Task<List<GoalCategory>> GetAllGoalCategories()
        {
            return await _aboutRepository.GetAllGoalCategories();
        }

        public async Task<GoalCategory> GetGoalCategoryById(Guid id)
        {
            return await _aboutRepository.GetGoalCategoryById(id);
        }

        public async Task<GoalCategory> UpdateGoalCategory(GoalCategory category)
        {
            GoalCategory categoryToUpdate = await GetGoalCategoryById(category.Id);
            categoryToUpdate.Name = category.Name;
            categoryToUpdate.Goals = category.Goals;
            return await _aboutRepository.UpdateGoalCategory(categoryToUpdate);
        }

        public async Task<GoalCategory> DeleteGoalCategoryById(Guid id)
        {
            return await _aboutRepository.DeleteGoalCategoryById(id);
        }

        public async Task<Goal> AddGoal(Goal goal)
        {
            goal.Active = true;
            goal.CreatedAt = DateTime.UtcNow;
            return await _aboutRepository.AddGoal(goal);
        }

        public async Task<List<Goal>> GetAllGoals(bool onlyActive, bool onlyCompleted)
        {
            if (onlyActive)
            {
                return await _aboutRepository.GetAllActiveGoals();
            } else if (onlyCompleted)
            {
                return await _aboutRepository.GetAllCompletedGoals();
            }
            return await _aboutRepository.GetAllGoals();
        }

        public async Task<Goal> GetGoalById(Guid id)
        {
            return await _aboutRepository.GetGoalById(id);
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
            return await _aboutRepository.UpdateGoal(goalToUpdate);
        }

        public async Task<Goal> DeleteGoalById(Guid id)
        {
            return await _aboutRepository.DeleteGoalById(id);
        }

        public async Task<List<Goal>> GetGoalsByCategoryId(Guid id)
        {
            return await _aboutRepository.GetGoalsByCategoryId(id);
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

        public async Task<Interest> AddInterest(Interest interest)
        {
            interest.CreatedAt = DateTime.UtcNow;
            return await _aboutRepository.AddInterest(interest);
        }

        public async Task<List<Interest>> GetAllInterests()
        {
            return await _aboutRepository.GetAllInterests();
        }

        public async Task<Interest> GetInterestById(Guid id)
        {
            return await _aboutRepository.GetInterestById(id);
        }

        public async Task<Interest> UpdateInterest(Interest interest)
        {
            Interest interestToUpdate = await GetInterestById(interest.Id);
            interestToUpdate.Description = interest.Description;
            interestToUpdate.Title = interest.Title;
            interestToUpdate.ImageUrl = interest.ImageUrl;
            interestToUpdate.LastUpdatedAt = DateTime.UtcNow;
            return await _aboutRepository.UpdateInterest(interestToUpdate);
        }

        public async Task<Interest> RemoveInterestById(Guid id)
        {
            return await _aboutRepository.RemoveInterestById(id);
        }
    }
}
