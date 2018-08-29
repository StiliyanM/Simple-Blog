namespace MyBlog.Web.Infrastructure.Mapping
{
    using AutoMapper;
    using MyBlog.Common.ViewModels.Posts;
    using MyBlog.Models;
    //using MyBlog.Common.Mapping;
    using System;
    using System.Linq;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
        }
    }
}
