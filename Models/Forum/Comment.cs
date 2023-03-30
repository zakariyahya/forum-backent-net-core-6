namespace forum.Models
{
    public class Comment : BaseModel
    {
        public Thread thread {get; set;}
        public User user {get; set;}
        public string content {get; set;}
    }
}