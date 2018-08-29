namespace MyBlog.Services
{
    using AutoMapper;
    using Data;

    public abstract class BaseService
    {
        protected BaseService(MyBlogDbContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }

        protected MyBlogDbContext DbContext { get; set; }

        protected IMapper Mapper { get; set; }
    }
}
