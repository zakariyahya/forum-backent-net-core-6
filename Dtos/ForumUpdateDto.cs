namespace forum.Dtos
{
    public class ForumUpdateDto
    {
        public int id { get; set;}
        public string? title { get; set; }
        public string? description { get; set; }
        public int content { get; set; }
    }
}