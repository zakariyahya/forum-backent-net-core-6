namespace forum.Models
{
    public class ForumSubscription : BaseModel
    {
        public MainForum forum {get; set;}
        public User user {get; set;} 
    }
}