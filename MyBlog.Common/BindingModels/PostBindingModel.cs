namespace MyBlog.Common.BindingModels
{
    using MyBlog.Common.ViewModels;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PostBindingModel
    {
        [StringLength(
          50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string Category { get; set; }

        public IEnumerable<CategoriesListingModel> Categories { get; set; }
    }
}
