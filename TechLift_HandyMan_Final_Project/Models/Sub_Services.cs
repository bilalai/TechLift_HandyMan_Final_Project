using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechLift_HandyMan_Final_Project.Models
{
    public class Sub_Services
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Sub_Service_Name{ get; set; }
        [Required]
        public string? Sub_Service_Descr { get; set; }
        [Required]
        public int? Sub_Service_Price { get; set; }
        [Required]

        [Column(TypeName = "nvarchar(50)")]
        public string? Sub_Service_Image { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile File { get; set; }



    }
}
