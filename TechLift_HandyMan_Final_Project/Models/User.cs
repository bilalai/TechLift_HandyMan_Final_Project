﻿using System.ComponentModel.DataAnnotations;

namespace TechLift_HandyMan_Final_Project.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string?  UserEmail { get; set; }
        public string? Password { get; set; }
        public string? ContactNo { get; set; }



    }
}
