namespace MyBlog.Services.Contracts
{
    using Common.ViewModels;
    using MyBlog.Common.BindingModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoryService
    {
        IEnumerable<CategoriesListingModel> All();

        Task<bool> CreateAsync(string name);

        Task DeleteAsync(int id);

        CategoryBindingModel ById(int id);

        Task EditAsync(int id, CategoryBindingModel model);

        IEnumerable<PostsByCategoryViewModel> CategoriesWithPosts();

    }
}
