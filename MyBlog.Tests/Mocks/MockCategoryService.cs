namespace MyBlog.Tests.Mocks
{
    using Moq;
    using MyBlog.Services.Contracts;

    public static class MockCategoryService
    {
        public static Mock<ICategoryService> GetCategoryService()
        {
            return new Mock<ICategoryService>();
        }
    }
}
