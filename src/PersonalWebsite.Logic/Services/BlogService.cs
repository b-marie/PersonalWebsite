using PersonalWebsite.Logic.Services.Interfaces;
using PersonalWebsite.Repository.Models;
using PersonalWebsite.Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalWebsite.Logic.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<Post>> GetAllPosts(bool onlyPublished)
        {
            if (onlyPublished)
            {
                return await _blogRepository.GetPublishedPosts();
            }
            return await _blogRepository.GetAllPosts();
        }

        public async Task<Post> GetPostById(Guid id)
        {
            return await _blogRepository.GetPostById(id);
        }

        public async Task<PostCategory> AddPostCategory(PostCategory category)
        {
            return await _blogRepository.AddPostCategory(category);
        }

        public async Task<List<PostCategory>> GetAllPostCategories()
        {
            return await _blogRepository.GetAllPostCategories();
        }

        public async Task<PostCategory> GetPostCategoryById(Guid id)
        {
            return await _blogRepository.GetPostCategoryById(id);
        }

        public async Task<PostCategory> UpdatePostCategory(PostCategory category)
        {
            PostCategory categoryToUpdate = await GetPostCategoryById(category.Id);
            categoryToUpdate.Name = category.Name;
            categoryToUpdate.Posts = category.Posts;
            return await _blogRepository.UpdatePostCategory(categoryToUpdate);
        }

        public async Task<PostCategory> DeletePostCategory(PostCategory category)
        {
            return await _blogRepository.DeletePostCategory(category);
        }

        public async Task<Tag> AddTag(Tag tag)
        {
            return await _blogRepository.AddTag(tag);
        }

        public async Task<List<Tag>> GetAllTags()
        {
            return await _blogRepository.GetAllTags();
        }

        public async Task<Tag> GetTagById(Guid id)
        {
            return await _blogRepository.GetTagById(id);
        }

        public async Task<Tag> UpdateTag(Tag tag)
        {
            Tag tagToUpdate = await GetTagById(tag.Id);
            tagToUpdate.Name = tag.Name;
            tagToUpdate.PostTags = tag.PostTags;
            return await _blogRepository.UpdateTag(tagToUpdate);
        }

        public async Task<Tag> DeleteTag(Tag tag)
        {
            return await _blogRepository.DeleteTag(tag);
        }

        public async Task<Post> AddPost(Post post)
        {
            post.CreatedAt = DateTime.UtcNow;
            return await _blogRepository.AddPost(post);
        }

        public async Task<Post> SavePost(Post post)
        {
            Post postToSave = await GetPostById(post.Id);
            postToSave.Title = post.Title;
            postToSave.ImageLink = post.ImageLink;
            postToSave.Body = post.Body;
            postToSave.Category = post.Category;
            postToSave.Tags = post.Tags;
            postToSave.LastSavedAt = DateTime.UtcNow;
            postToSave.LastUpdatedAt = DateTime.UtcNow;
            return await _blogRepository.SavePost(postToSave);
        }

        public async Task<Post> PublishPost(Post post)
        {
            Post postToPublish = await GetPostById(post.Id);
            postToPublish.Title = post.Title;
            postToPublish.ImageLink = post.ImageLink;
            postToPublish.Body = post.Body;
            postToPublish.Category = post.Category;
            postToPublish.Tags = post.Tags;
            postToPublish.LastSavedAt = DateTime.UtcNow;
            postToPublish.PublishedAt = DateTime.UtcNow;
            postToPublish.LastUpdatedAt = DateTime.UtcNow;
            postToPublish.Published = true;
            return await _blogRepository.PublishPost(postToPublish);
        }

        public async Task<Post> DeletePost(Post post)
        {
            return await _blogRepository.DeletePost(post);
        }

        public async Task<PostTag> GetPostTagById(Guid id)
        {
            return await _blogRepository.GetPostTagById(id);
        }

        public async Task<List<Post>> GetPostsByTagId(Guid id)
        {
            return await _blogRepository.GetPostsByTagId(id);
        }

        public async Task<List<Post>> GetPostsByCategoryId(Guid id)
        {
            return await _blogRepository.GetPostsByCategoryId(id);
        }
    }
}
