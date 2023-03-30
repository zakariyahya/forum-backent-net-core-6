namespace forum.Models

{
    public partial class Post
    {
        public int Id { get; set; }
        public User user {get; set;}
        public string Description { get; set; }
        public string? Imagepath { get; set; }
        public DateTime Ts { get; set; }
        public bool Published { get; set; }
    }
}