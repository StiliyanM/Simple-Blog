namespace MyBlog.Services.Contracts
{
    using System.Collections.Generic;
    using Common.ViewModels;

    public interface IUserService : IService
    {
        IEnumerable<UserListingViewModel> All(string currentUserId);
    }
}
