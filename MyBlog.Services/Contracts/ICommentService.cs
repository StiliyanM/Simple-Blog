namespace MyBlog.Services.Contracts
{
    using System.Threading.Tasks;

    public interface ICommentService : IService
    {
        Task CreateAsync(string userId, int postId, string content);
    }
}
