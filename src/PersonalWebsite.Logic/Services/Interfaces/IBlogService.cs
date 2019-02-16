using PersonalWebsite.Repository.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalWebsite.Logic.Services.Interfaces
{
    public interface IBlogService
    {
        Task<List<Post>> GetAllPosts(bool onlyPublished);

        Task<Post> GetPostById(Guid id);

        Task<PostCategory> AddPostCategory(PostCategory category);

        Task<List<PostCategory>> GetAllPostCategories();

        Task<PostCategory> GetPostCategoryById(Guid id);

        Task<PostCategory> UpdatePostCategory(PostCategory category);

        Task<PostCategory> DeletePostCategory(PostCategory category);

        Task<Tag> AddTag(Tag tag);

        Task<List<Tag>> GetAllTags();

        Task<Tag> GetTagById(Guid id);

        Task<Tag> UpdateTag(Tag tag);

        Task<Tag> DeleteTag(Tag tag);

        Task<Post> AddPost(Post post);

        Task<Post> SavePost(Post post);

        Task<Post> PublishPost(Post post);

        Task<Post> DeletePost(Post post);

        Task<PostTag> GetPostTagById(Guid id);

        Task<List<Post>> GetPostsByTagId(Guid id);

        Task<List<Post>> GetPostsByCategoryId(Guid id);
    }
}
