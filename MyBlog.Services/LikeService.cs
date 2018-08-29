namespace MyBlog.Services
{
    using AutoMapper;
    using Contracts;
    using MyBlog.Data;
    using MyBlog.Models;
    using System.Linq;
    using System.Threading.Tasks;

    public class LikeService : BaseService, ILikeService
    {
        public LikeService(MyBlogDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task CreateAsync(int postId, string userId)
        {

            if(this.DbContext.Likes.Any(l => l.PostId == postId && l.UserId == userId))
            {
                return;
            }

            var like = new Like
            {
                PostId = postId,
                UserId = userId,
                IsClicked = true
            };

            await this.DbContext.AddAsync(like);

            await DbContext.SaveChangesAsync();
        }
    }
}
