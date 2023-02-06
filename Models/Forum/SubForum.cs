namespace forum.Models
{
    public class SubForum : BaseModel
    {
        public string? title { get; set; }
        public string? description { get; set; }
        public int content { get; set; }
        public Forum forum { get; set; }
    }
}