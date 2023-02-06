
namespace forum.Models
{
    public class Forum : BaseModel
    {
        public string? title { get; set; }
        public string? description { get; set; }
        public int content { get; set; }
    }
}