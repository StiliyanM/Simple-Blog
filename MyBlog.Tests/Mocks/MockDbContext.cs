namespace MyBlog.Tests.Mocks
{
    using Microsoft.EntityFrameworkCore;
    using MyBlog.Data;
    using System;

    public static class MockDbContext
    {
        public static MyBlogDbContext GetContext()
        {
            var dbOptions = new DbContextOptionsBuilder<MyBlogDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new MyBlogDbContext(dbOptions);
        }
    }
}
