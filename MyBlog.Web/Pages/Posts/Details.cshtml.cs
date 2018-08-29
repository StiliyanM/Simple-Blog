namespace MyBlog.Web.Pages.Posts
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using MyBlog.Common.ViewModels.Posts;
    using MyBlog.Models;
    using MyBlog.Services.Contracts;

    public class DetailsModel : PageModel
    {
        private readonly IPostService posts;
        private readonly UserManager<User> userManager;

        public PostDetailsViewModel Post { get; set; }

        public DetailsModel(IPostService posts, UserManager<User> userManager)
        {
            this.posts = posts;
            this.userManager = userManager;
        }

        public IActionResult OnGet(int id)
        {
            this.Post = this.posts.Details(id);

            if (Post == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}