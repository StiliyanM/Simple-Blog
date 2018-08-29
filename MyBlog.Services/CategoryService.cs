namespace MyBlog.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Contracts;
    using Common.BindingModels;
    using Common.ViewModels;
    using Data;
    using Models;
    using System.Threading.Tasks;

    public class CategoryService : BaseService ,ICategoryService
    {
        public CategoryService(MyBlogDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public IEnumerable<CategoriesListingModel> All()
        {
            var categories = this.DbContext.Categories.ToList();

            var model = Mapper.Map<IEnumerable<CategoriesListingModel>>(categories);

            return model;
        }

        public CategoryBindingModel ById(int id)
        {
            var category = this.DbContext.Categories
                .FirstOrDefault(c => c.Id == id);

            var model = Mapper.Map<CategoryBindingModel>(category);

            return model;
        }

        public async Task<bool> CreateAsync(string name)
        {
            var exists = this.DbContext.Categories.Any(c => c.Name == name);

            if (exists)
            {
                return false;
            }

            await this.DbContext.Categories.AddAsync(new Category
            {
                Name = name
            });

            await this.DbContext.SaveChangesAsync();

            return true;
        }

        public async Task DeleteAsync(int id)
        {
            var category = this.DbContext.Categories
                .FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return;
            }

            this.DbContext.Categories.Remove(category);

            await this.DbContext.SaveChangesAsync();
        }

        public async Task EditAsync(int id, CategoryBindingModel model)
        {
            var category = this.DbContext.Categories
                .FirstOrDefault(c => c.Id == id);

            if(category == null)
            {
                return;
            }

            category.Name = model.Name;

            await DbContext.SaveChangesAsync();
        }

        public IEnumerable<PostsByCategoryViewModel> CategoriesWithPosts()
        {
            return this.DbContext.Categories
                .Select(c => new PostsByCategoryViewModel
                {
                    Name = c.Name,
                    Posts = Mapper.Map<IEnumerable<PostNamesViewModel>>(c.Posts)
                }).ToList();
        }
    }
}
