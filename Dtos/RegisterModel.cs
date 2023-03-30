using System.ComponentModel.DataAnnotations;

namespace forum.Dtos
{
    public class RegisterModel
    {
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        public string? [] roles {get; set;}
        // public string image { get; set; }
    }
}