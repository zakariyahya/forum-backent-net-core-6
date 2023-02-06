namespace forum.Models
{
    public class UserRole : BaseModel
    {
        public User user {get; set;}
        public Role role {get; set;}
    }
}