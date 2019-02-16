using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Repository.Models;
using PersonalWebsite.Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Repository.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly PersonalWebsiteDbContext _context;

        public BlogRepository(PersonalWebsiteDbContext context)
        {
            _context = context;
        }

        public async Task<List<Post>> GetAllPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<List<Post>> GetPublishedPosts()
        {
            return await _context.Posts.Where(x => x.Published == true).ToListAsync();
        }

        public async Task<Post> GetPostById(Guid id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public async Task<PostCategory> AddPostCategory(PostCategory category)
        {
            await _context.PostCategories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<List<PostCategory>> GetAllPostCategories()
        {
            return await _context.PostCategories.ToListAsync();
        }

        public async Task<PostCategory> GetPostCategoryById(Guid id)
        {
            return await _context.PostCategories.FindAsync(id);
        }

        public async Task<PostCategory> UpdatePostCategory(PostCategory category)
        {
            _context.PostCategories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<PostCategory> DeletePostCategory(PostCategory category)
        {
            _context.PostCategories.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Tag> AddTag(Tag tag)
        {
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
            return tag;
        }

        public async Task<List<Tag>> GetAllTags()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<Tag> GetTagById(Guid id)
        {
            return await _context.Tags.FindAsync(id);
        }

        public async Task<Tag> UpdateTag(Tag tag)
        {
            _context.Tags.Update(tag);
            await _context.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag> DeleteTag(Tag tag)
        {
            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
            return tag;
        }

        public async Task<Post> AddPost(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<Post> SavePost(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<Post> PublishPost(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<Post> DeletePost(Post post)
        {
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<PostTag> GetPostTagById(Guid id)
        {
            return await _context.PostTag.Where(x => x.TagId == id).FirstOrDefaultAsync();
        }

        public async Task<List<Post>> GetPostsByTagId(Guid id)
        {
            PostTag tag = await GetPostTagById(id);
            return await _context.Posts.Where(x => x.Tags.Contains(tag)).OrderByDescending(p => p.PublishedAt)
                .ToListAsync();
        }

        public async Task<List<Post>> GetPostsByCategoryId(Guid id)
        {
            PostCategory category = await GetPostCategoryById(id);
            return await _context.Posts.Where(x => x.Category == category).OrderByDescending(p => p.PublishedAt)
                .ToListAsync();
        }

    }
}
