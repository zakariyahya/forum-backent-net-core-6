
namespace forum.Models
{
    public class MainForum : BaseModel
    {
        public string? title { get; set; }
        public string? description { get; set; }
        public string image { get; set; }
        public string url {get; set;}
    }
}