namespace forum.Models
{
    public class Thread : BaseModel
    {
        public SubForum subForum {get; set;}
        public User user {get; set;}
        public string title {get; set;}
        public string content {get; set;}
        public string image { get; set; }
        public string url {get; set;}

    }
}