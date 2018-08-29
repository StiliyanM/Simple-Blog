namespace MyBlog.Web.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using Web.Models;
    using Services.Contracts;

    public class HomeController : Controller
    {
        private readonly IPostService posts;

        public HomeController(IPostService posts)
        {
            this.posts = posts;
        }

        public IActionResult Index()
        {
            var posts = this.posts.All();
            return View(posts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
