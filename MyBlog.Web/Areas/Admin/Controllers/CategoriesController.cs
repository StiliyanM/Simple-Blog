namespace MyBlog.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.Common.BindingModels;
    using MyBlog.Web.Infrastructure.Extensions;
    using Services.Contracts;
    using System.Threading.Tasks;

    public class CategoriesController : AdminController
    {
        private readonly ICategoryService categories;

        public CategoriesController(ICategoryService categories)
        {
            this.categories = categories;
        }

        public IActionResult Index()
        {
            var model = this.categories.All();

            return View(model);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CategoryBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var success = await this.categories.CreateAsync(model.Name);

            if (!success)
            {
                this.ModelState.AddModelError("", "This category already exists!");

                return View();
            }

            this.TempData.AddSuccessMessage(string.Format(WebConstants.CreatedMessage, "Category"));

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var category = this.categories.ById(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CategoryBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await this.categories.EditAsync(id, model);

            this.TempData.AddSuccessMessage(string.Format(WebConstants.EdittedMessage, "Category"));
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var category = this.categories.ById(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, CategoryBindingModel model)
        {
            await this.categories.DeleteAsync(id);

            this.TempData.AddSuccessMessage(string.Format(WebConstants.DeletedMessage, "Category"));

            return RedirectToAction("Index");
        }
    }
}

