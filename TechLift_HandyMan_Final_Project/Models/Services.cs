using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechLift_HandyMan_Final_Project.Models
{
    public class Services
    {
        [Key]
        public int Id { get; set; }
        public string? ServiceName { get; set; }

        [Column (TypeName="nvarchar(50)")]
        public string ServiceImage { get; set; }

       
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile File { get; set; }

    }
}
