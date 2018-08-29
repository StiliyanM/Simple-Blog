using System.ComponentModel.DataAnnotations;

namespace MyBlog.Common.BindingModels
{
    public class CategoryBindingModel
    {
        [Required]
        public string Name { get; set; }
    }
}
