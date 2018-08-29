namespace MyBlog.Common.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class CommentBindingModel
    {
        [Required]
        public string Content { get; set; }
    }
}
