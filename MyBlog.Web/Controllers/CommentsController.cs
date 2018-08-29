namespace MyBlog.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.Common.BindingModels;
    using MyBlog.Models;
    using MyBlog.Services.Contracts;
    using MyBlog.Web.Infrastructure.Extensions;
    using System.Threading.Tasks;

    public class CommentsController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly ICommentService comments;

        public CommentsController(UserManager<User> userManager, ICommentService comments)
        {
            this.userManager = userManager;
            this.comments = comments;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(int postId, CommentBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = this.userManager.GetUserId(this.User);

            await this.comments.CreateAsync(userId, postId, model.Content);

            this.TempData.AddSuccessMessage("Comment succesfully posted!");

            return RedirectToAction("Details", "Posts", new { id = postId });
        }
    }
}
