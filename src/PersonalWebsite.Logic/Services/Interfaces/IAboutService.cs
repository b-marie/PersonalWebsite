﻿using PersonalWebsite.Repository.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalWebsite.Logic.Services.Interfaces
{
    public interface IAboutService
    {
        Task<About> AddAbout(About about);

        Task<About> GetAbout();

        Task<About> UpdateAbout(About about);

        Task<CommunityInvolvement> AddCommunityInvolvement(CommunityInvolvement communityInvolvement);

        Task<List<CommunityInvolvement>> GetAllCommunityInvolvement();

        Task<CommunityInvolvement> GetCommunityInvolvementById(Guid id);

        Task<CommunityInvolvement> DeleteCommunityInvolvementById(Guid id);

        Task<CommunityInvolvement> UpdateCommunityInvolvement(CommunityInvolvement communityInvolvement);

        Task<List<CommunityInvolvement>> GetAllCommunityInvolvementBySkill(Guid id);

        Task<Book> AddBook(Book book);

        Task<List<Book>> GetAllBooks();

        Task<Book> GetBookById(Guid id);

        Task<Book> UpdateBook(Book book);

        Task<Book> DeleteBookById(Guid id);

        Task<Employment> AddEmployment(Employment employment);

        Task<List<Employment>> GetAllEmployment();

        Task<Employment> GetEmploymentById(Guid id);

        Task<Employment> UpdateEmployment(Employment employment);

        Task<Employment> DeleteEmploymentById(Guid id);

        Task<List<Employment>> GetAllEmploymentBySkillId(Guid id);

        Task<GoalCategory> AddGoalCategory(GoalCategory category);

        Task<List<GoalCategory>> GetAllGoalCategories();

        Task<GoalCategory> GetGoalCategoryById(Guid id);

        Task<GoalCategory> UpdateGoalCategory(GoalCategory category);

        Task<GoalCategory> DeleteGoalCategoryById(Guid id);

        Task<Goal> AddGoal(Goal goal);

        Task<List<Goal>> GetAllGoals(bool onlyActive, bool onlyCompleted);

        Task<Goal> GetGoalById(Guid id);

        Task<Goal> UpdateGoal(Goal goal);

        Task<Goal> DeleteGoalById(Guid id);

        Task<List<Goal>> GetGoalsByCategoryId(Guid id);

        Task<Goal> CompleteGoalById(Guid id);

        Task<Interest> AddInterest(Interest interest);

        Task<List<Interest>> GetAllInterests();

        Task<Interest> GetInterestById(Guid id);

        Task<Interest> UpdateInterest(Interest interest);

        Task<Interest> RemoveInterestById(Guid id);
    }
}
