namespace MyBlog.Services.Contracts
{
    using System.Threading.Tasks;

    public interface ILikeService : IService
    {
        Task CreateAsync(int postId, string userId);
    }
}
