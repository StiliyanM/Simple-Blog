namespace MyBlog.Services
{
    using AutoMapper;
    using Contracts;
    using MyBlog.Data;
    using MyBlog.Models;
    using System.Threading.Tasks;

    public class CommentService : BaseService ,ICommentService
    {
        public CommentService(MyBlogDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task CreateAsync(string userId, int postId, string content)
        {
            var comment = new Comment
            {
                AuthorId = userId,
                Content = content,
                PostId = postId
            };

           await this.DbContext.Comments.AddAsync(comment);
           await this.DbContext.SaveChangesAsync();
        }
    }
}
