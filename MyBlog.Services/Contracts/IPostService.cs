namespace MyBlog.Services.Contracts
{
    using System.Collections.Generic;
    using Common.ViewModels.Posts;
    using MyBlog.Common.BindingModels;
    using System.Threading.Tasks;

    public interface IPostService : IService
    {
        Task<int> CreateAsync(string title, string content, string categoryName, string authorId);

        IEnumerable<PostsListingViewModel> All();

        PostDetailsViewModel Details(int id);

        Task EditAsync(int id, PostBindingModel model);

        Task DeleteAsync(int id);

        PostBindingModel ById(int id);

        IEnumerable<PostArchiveViewModel> Archives();
        bool Exists(string title);
    }
}
