namespace MyBlog.Common.ViewModels.Posts
{
    using System;

    public class PostsListingViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime PublishDate { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }
    }
}
