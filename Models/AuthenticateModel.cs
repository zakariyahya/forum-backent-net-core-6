using System.ComponentModel.DataAnnotations;

namespace forum.Models{
    public class AuthenticateModel
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}