namespace MyBlog.Common.ViewModels.Posts
{
    using System;
    using System.Collections.Generic;

    public class PostDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        public IEnumerable<CommentListingViewModel> Comments { get; set; }

        public IEnumerable<LikeViewModel> Likes { get; set; }
    }

    public class LikeViewModel
    {
        public bool IsClicked { get; set; }

        public int PostId { get; set; }

        public string Username { get; set; }
    }

    public class CommentListingViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
