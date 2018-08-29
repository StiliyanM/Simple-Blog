namespace MyBlog.Tests.Web.Areas.Admin
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;
    using Moq;
    using MyBlog.Common.BindingModels;
    using MyBlog.Common.ViewModels;
    using MyBlog.Services.Contracts;
    using MyBlog.Web;
    using MyBlog.Web.Areas.Admin.Controllers;
    using System.Linq;
    using System.Threading.Tasks;

    [TestClass]
    public class CategoriesControllerTests
    {
        private Mock<ICategoryService> mockRepository;

        private const string name = "Category";

        [TestInitialize]
        public void Initialize()
        {
            this.mockRepository = MockCategoryService
                    .GetCategoryService();
        }

        [TestMethod]
        public void CategoriesControllerShouldBeInAdminArea()
        {
            var controller = typeof(CategoriesController);

            var areaAttribute = controller
                .GetCustomAttributes(true)
                .FirstOrDefault(a => a.GetType() == typeof(AreaAttribute))
                as AreaAttribute;

            Assert.IsNotNull(areaAttribute);
            Assert.AreEqual(WebConstants.AdminArea, areaAttribute.RouteValue);
        }

        [TestMethod]
        public void CategoriesControllerShouldBeOnlyForAdminUsers()
        {
            var controller = typeof(CategoriesController);

            var areaAttribute = controller
                .GetCustomAttributes(true)
                .FirstOrDefault(a => a.GetType() == typeof(AuthorizeAttribute))
                as AuthorizeAttribute;

            Assert.IsNotNull(areaAttribute);
            Assert.AreEqual(WebConstants.AdministratorRole, areaAttribute.Roles);
        }

        [TestMethod]
        public void Index_ReturnsAll()
        {
            var categoriesModel = new CategoriesListingModel
            {
                Name = name
            };

            this.mockRepository
           .Setup(service => service.All())
           .Returns(new[] { categoriesModel });

            var controller = new CategoriesController(mockRepository.Object);

            var result = controller.Index();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var model = (result as ViewResult).Model;
            Assert.IsNotNull(model);

        }

        [TestMethod]
        public async Task Create_WithValid_ShouldRedirectToIndex()
        {
            var model = new CategoryBindingModel
            {
                Name = name
            };

            this.mockRepository
                .Setup(repo => repo.CreateAsync(model.Name))
                .Returns(Task.FromResult(true));

            var tempData = new Mock<ITempDataDictionary>();
            tempData
                .SetupSet(t => t[WebConstants.TempDataSuccessMessageKey] = It.IsAny<string>());

            var controller = new CategoriesController(this.mockRepository.Object);

            controller.TempData = tempData.Object;

            var result = await controller.Create(model);
            var actionName = (result as RedirectToActionResult).ActionName;

            Assert.AreEqual("Index", actionName);
        }

        [TestMethod]
        public async Task Create_WithInvalidModelState_ShouldReturnView()
        {            
            var controller = new CategoriesController(this.mockRepository.Object);

            var model = new CategoryBindingModel();

            controller.ModelState.AddModelError(string.Empty, "Error");

            var result =  await controller.Create(model);

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task Create_WithAlreadyExisting_ShouldAddErrorToModelState()
        {
            this.mockRepository
                .Setup(repo => repo.CreateAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(false));

            var controller = new CategoriesController(this.mockRepository.Object);

            var result = await controller.Create(new CategoryBindingModel
            {
                Name = name
            });

            var errorMessage = "This category already exists!";

            var error = controller.ModelState.Values.FirstOrDefault()
                .Errors.FirstOrDefault().ErrorMessage;

            Assert.AreEqual(error, errorMessage);
        }
    }
}
