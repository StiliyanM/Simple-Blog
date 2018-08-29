namespace MyBlog.Web.Pages.Posts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using MyBlog.Common.ViewModels.Posts;
    using MyBlog.Models;
    using MyBlog.Services.Contracts;

    public class ArchivesModel : PageModel
    {
        private readonly IPostService posts;
        private readonly UserManager<User> userManager;

        public IEnumerable<PostArchiveViewModel> Archives { get; set; }

        public ArchivesModel(IPostService posts, UserManager<User> userManager)
        {
            this.posts = posts;
            this.userManager = userManager;
        }

        public void OnGet()
        {
            this.Archives = this.posts.Archives();

            Page();
        }
    }
}