namespace MyBlog.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Identity;
    using MyBlog.Models;
    using MyBlog.Common.BindingModels;
    using MyBlog.Services.Contracts;
    using System.Threading.Tasks;
    using MyBlog.Web.Infrastructure.Extensions;

    public class PostsController : AdminController
    {
        private readonly IPostService posts;
        private readonly UserManager<User> userManager;
        private readonly ICategoryService categories;

        public PostsController(IPostService posts,
                               UserManager<User> userManager,
                               ICategoryService categories)
        {
            this.posts = posts;
            this.userManager = userManager;
            this.categories = categories;
        }

        public IActionResult Create()
        {
            var model = new PostBindingModel
            {
                Categories = this.categories.All()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostBindingModel model)
        {
            var userId = this.userManager.GetUserId(this.User);

            if (!ModelState.IsValid)
            {
                model.Categories = this.categories.All();

                return View(model);
            }

            if (posts.Exists(model.Title))
            {
                this.ModelState.AddModelError("", $"Post {model.Title} already exists!");

                model.Categories = this.categories.All();

                return View(model);
            }

            var postId = await this.posts.CreateAsync(model.Title, model.Content, model.Category, userId);

            return RedirectToPage("/Posts/Details", new { id = postId });
        }

        public IActionResult Edit(int id)
        {
            var post = this.posts.ById(id);

            if (post == null)
            {
                return NotFound();
            }

            post.Categories = categories.All();

            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PostBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = categories.All();

                return View(model);
            }

            if (posts.Exists(model.Title))
            {
                this.ModelState.AddModelError("", $"Post {model.Title} already exists!");
            }

            await this.posts.EditAsync(id, model);

            this.TempData.AddSuccessMessage(string.Format(WebConstants.EdittedMessage, "Post"));

            return Redirect("/");
        }

        public IActionResult Delete(int id)
        {
            var post = this.posts.ById(id);

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, PostBindingModel model)
        {
            await this.posts.DeleteAsync(id);

            this.TempData.AddSuccessMessage(string.Format(WebConstants.DeletedMessage, "Post"));

            return Redirect("/");
        }
    }
}
