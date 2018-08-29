namespace MyBlog.Common.ViewModels
{
    using System.Collections.Generic;

    public class PostsByCategoryViewModel
    {
        public string Name { get; set; }

        public IEnumerable<PostNamesViewModel> Posts { get; set; }
    }

    public class PostNamesViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
