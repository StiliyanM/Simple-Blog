namespace MyBlog.Models
{
    public class Like
    {
        public int Id { get; set; }

        public User User { get; set; }
        public string UserId { get; set; }

        public Post Post { get; set; }
        public int PostId { get; set; }

        public bool IsClicked { get; set; }
    }
}
