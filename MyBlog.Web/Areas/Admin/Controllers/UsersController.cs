namespace MyBlog.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.Common.BindingModels;
    using MyBlog.Models;
    using MyBlog.Services.Contracts;
    using MyBlog.Web.Infrastructure.Extensions;
    using System.Threading.Tasks;

    public class UsersController : AdminController
    {
        private readonly UserManager<User> userManager;
        private readonly IUserService users;

        public UsersController(UserManager<User> userManager, IUserService users)
        {
            this.userManager = userManager;
            this.users = users;
        }

        public IActionResult Index()
        {
            var currentUserId = this.userManager.GetUserId(this.User);

            var model = this.users.All(currentUserId);

            return View(model);
        }

        public async Task<IActionResult> Delete(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return NotFound();
            }

            var user = await this.userManager.FindByNameAsync(username);

            if (user == null)
            {
                return NotFound();
            }

            var model = new UserBindingModel
            {
                Username = username
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UserBindingModel model)
        {
            var user = await this.userManager.FindByNameAsync(model.Username);

            await this.userManager.DeleteAsync(user);
            return RedirectToAction("Index");
        }

        public IActionResult Ban(UserLockoutBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> BanAsync(UserLockoutBindingModel model)
        {
            var user = await this.userManager.FindByNameAsync(model.Username);

            await this.userManager.SetLockoutEndDateAsync(user, model.LockoutEnd);

            this.TempData.AddSuccessMessage($"User {user.UserName} successfully banned!");
            return RedirectToAction("Index");
        }

    }
}
