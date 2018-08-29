namespace MyBlog.Tests.Mocks
{
    using AutoMapper;
    using MyBlog.Web.Infrastructure.Mapping;

    public static class MockAutoMapper
    {
        private static bool testsInitialized;

        public static IMapper GetMapper()
        {
            if (!testsInitialized)
            {
                Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());
                testsInitialized = true;
            }

            return Mapper.Instance;
        }

    }
}
