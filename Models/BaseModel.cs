using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace forum.Models
{
    public abstract class BaseModel
    {
        public BaseModel()
        {
            createdBy = "System";
            createdTime = DateTime.Now;
            lastModifiedBy = "";
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string createdBy { get; set; }
        public DateTime? createdTime { get; set; }
        public string lastModifiedBy { get; set; }
        public DateTime? lastModifiedTime { get; set; }
    }
}