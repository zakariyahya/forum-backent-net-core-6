namespace forum.Models
{
    public class FileUpload
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public string Imagepath { get; set; }
        public DateTime Ts { get; set; }
    }
}