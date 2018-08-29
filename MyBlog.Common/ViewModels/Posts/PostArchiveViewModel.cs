namespace MyBlog.Common.ViewModels.Posts
{
    using System;
    using System.Collections.Generic;

    public class PostArchiveViewModel
    {
        public int Month { get; set; }
        public int Year { get; set; }

        public IEnumerable<PostConciseViewModel> Posts { get; set; }
    }

    public class PostConciseViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
