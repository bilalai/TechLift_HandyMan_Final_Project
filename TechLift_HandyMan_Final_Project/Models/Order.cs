using System.ComponentModel.DataAnnotations;

namespace TechLift_HandyMan_Final_Project.Models
{
    public class Order
    {
        [Key]
        public string? OrderID { get; set; }
        public string? OrderName { get; set; }
        public int? Sub_Service_Price { get; set; }
        public string? Total { get; set; }
    }
}
