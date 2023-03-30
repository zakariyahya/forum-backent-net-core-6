using System.ComponentModel.DataAnnotations;

namespace forum.Models
{
    public class User
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string username { get; set; }
        [EmailAddress]
        public string email { get; set; }
        public string password {get; set;}
        // public byte[] passwordHash { get; set; }
        // public byte[] passwordSalt { get; set; } 
        // public string roles { get; set; }
        // public string image { get; set; }
        // public string url {get; set;}
        // public string bio {get; set;}
        // public string github {get; set;}
        // public string whatsapp {get; set;}
        // public string linkedin {get; set;}
        // public string gender {get; set;}
        // public string address {get; set;}
        // public string hobies {get; set;}
        // public DateTime birth {get; set;}
    }
}