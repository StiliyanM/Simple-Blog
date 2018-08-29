namespace MyBlog.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.Models;
    using Services.Contracts;
    using System.Threading.Tasks;

    public class LikesController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly ILikeService likes;

        public LikesController(ILikeService likes, UserManager<User> userManager)
        {
            this.userManager = userManager;
            this.likes = likes;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Like(int postId)
        {
            var userId = this.userManager.GetUserId(User);

            await this.likes.CreateAsync(postId, userId);

            return RedirectToAction("Details", "Posts", new { id = postId });
        }
    }
}
