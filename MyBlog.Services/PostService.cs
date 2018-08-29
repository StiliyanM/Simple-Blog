namespace MyBlog.Services
{
    using AutoMapper;
    using Contracts;
    using Data;
    using Models;
    using MyBlog.Common.BindingModels;
    using MyBlog.Common.ViewModels.Posts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class PostService : BaseService, IPostService
    {
        public PostService(MyBlogDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public IEnumerable<PostsListingViewModel> All()
        {
            return this.DbContext.Posts
                .Select(p => new PostsListingViewModel
                {
                    Id = p.Id,
                    Author = p.Author.UserName,
                    Content = p.Content,
                    Title = p.Title,
                    PublishDate = p.PublishDate
                })
                .OrderByDescending(p => p.PublishDate)
                .ToList();
        }

        public async Task<int> CreateAsync(string title, string content, string categoryName, string authorId)
        {
            var category = this.DbContext.Categories.FirstOrDefault(c => c.Name == categoryName);

            var post = new Post
            {
                AuthorId = authorId,
                Category = category,
                Content = content,
                Title = title
            };

            await this.DbContext.AddAsync(post);
            await this.DbContext.SaveChangesAsync();

            return post.Id;
        }

        public PostDetailsViewModel Details(int id)
        {
            return this.DbContext.Posts
                .Where(p => p.Id == id)
                .Select(p => new PostDetailsViewModel
                {
                    Id = id,
                    Author = p.Author.UserName,
                    Category = p.Category.Name,
                    Content = p.Content,
                    PublishDate = p.PublishDate,
                    Title = p.Title,
                    Comments = p.Comments
                                .Select(c => new CommentListingViewModel
                                {
                                    Id = id,
                                    Author = c.Author.UserName,
                                    PublishDate = c.PublishDate,
                                    Content = c.Content
                                }).ToList(),
                    Likes = p.Likes
                                .Select(l => new LikeViewModel
                                {
                                    PostId = p.Id,
                                    Username = l.User.UserName,
                                    IsClicked = l.IsClicked
                                })
                })
                .FirstOrDefault();
        }

        public async Task EditAsync(int id, PostBindingModel model)
        {
            var category = this.DbContext.Categories.FirstOrDefault(c => c.Name == model.Category);

            var post = this.DbContext.Posts.FirstOrDefault(p => p.Id == id);

            if (post == null)
            {
                return;
            }

            post.Title = model.Title;
            post.Category = category;
            post.Content = model.Content;

            await this.DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var post = this.DbContext.Posts.Find(id);

            if (post != null)
            {
                this.DbContext.Posts.Remove(post);
            }

            await this.DbContext.SaveChangesAsync();
        }

        public PostBindingModel ById(int id)
        {
            return this.DbContext
                .Posts.Where(p => p.Id == id)
                .Select(p => new PostBindingModel
                {
                    Title = p.Title,
                    Category = p.Category.Name,
                    Content = p.Content
                }).FirstOrDefault();
        }

        public IEnumerable<PostArchiveViewModel> Archives()
        {
            return this.DbContext.Posts
                .GroupBy(p => new { p.PublishDate.Year, p.PublishDate.Month })
                .Select(g => new PostArchiveViewModel
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    Posts = g.Select(p => new PostConciseViewModel
                    {
                        Id = p.Id,
                        Title = p.Title
                    }).ToList(),
                })
                .OrderByDescending(e => e.Year)
                .ThenByDescending(e => e.Month)
                .ToList();

        }

        public bool Exists(string title)
        {
            return this.DbContext.Posts.Any(p => p.Title == title);
        }
    }
}
