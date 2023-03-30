namespace forum.Models
{
    public class SubForum : BaseModel
    {
        public string? title { get; set; }
        public string? description { get; set; }
        public string image { get; set; }
        public string url {get; set;}
        public MainForum mainForum { get; set; }
    }
}