namespace MyBlog.Models
{
    using System.Collections.Generic;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime PublishDate { get; set; } = DateTime.UtcNow;

        public string AuthorId { get; set; }

        public User Author { get; set; }

        public int PostId { get; set; }

        public Post Post { get; set; }

    }
}