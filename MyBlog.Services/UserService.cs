namespace MyBlog.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Contracts;
    using Common.ViewModels;
    using MyBlog.Data;

    public class UserService : BaseService, IUserService
    {
        public UserService(MyBlogDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public IEnumerable<UserListingViewModel> All(string currentUserId)
        {
            var users = this.DbContext.Users
                    .Where(u => u.Id != currentUserId)
                    .ToList();

            var model = Mapper.Map<IEnumerable<UserListingViewModel>>(users);

            return model;
        }
    }
}
