namespace MyBlog.Web.Pages
{ 
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Common.ViewModels;
    using Services.Contracts;

    public class PostsModel : PageModel
    {
        private readonly ICategoryService categories;

        public PostsModel(ICategoryService categories)
        {
            this.categories = categories;
        }

        public IEnumerable<PostsByCategoryViewModel> Categories { get; set; }

        public void OnGet()
        {
            this.Categories = this.categories.CategoriesWithPosts();
        }
    }
}