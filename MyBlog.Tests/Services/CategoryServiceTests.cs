namespace MyBlog.Tests.Services
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyBlog.Services;
    using MyBlog.Services.Contracts;
    using Mocks;
    using MyBlog.Data;
    using MyBlog.Models;
    using System.Linq;
    using System.Threading.Tasks;

    [TestClass]
    public class CategoryServiceTests
    {
        private ICategoryService categories;
        private MyBlogDbContext dbContext;

        private const string name = "category";

        [TestInitialize]
        public void Initialize()
        {
            this.dbContext = MockDbContext.GetContext();
            var mapper = MockAutoMapper.GetMapper();

            this.categories = new CategoryService(this.dbContext, mapper);
        }

        [TestMethod]
        public void All_WithAFew_ShouldReturnAll()
        {
            var first = new Category { Id = 1, Name = "First" };
            var second = new Category { Id = 2, Name = "Second" };
            var third = new Category { Id = 3, Name = "Third" };

            this.dbContext.AddRange(first, second, third);

            this.dbContext.SaveChanges();

            var result = this.categories.All();

            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void All_WithNone_ShouldReturnNone()
        {
            var result = this.categories.All();

            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public async Task Create_WithCorrectData_ShouldReturnTrue()
        {
            var success = await this.categories.CreateAsync(name);

            var category = this.dbContext.Categories.FirstOrDefault(c => c.Name == name);

            Assert.IsTrue(success);
            Assert.IsNotNull(category);
        }

        [TestMethod]
        public async Task Create_WithAlreadyExisting_ShouldReturnFalse()
        {
            this.dbContext.Add(new Category { Name = name });

            this.dbContext.SaveChanges();

            var success = await this.categories.CreateAsync(name);

            Assert.IsFalse(success);
        }
    }
}
