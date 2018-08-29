namespace MyBlog.Common.BindingModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserLockoutBindingModel
    {
        [Required]
        public string Username { get; set; }

        public DateTime? LockoutEnd { get; set; }
    }
}
