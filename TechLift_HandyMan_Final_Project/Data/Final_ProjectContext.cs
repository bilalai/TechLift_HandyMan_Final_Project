using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechLift_HandyMan_Final_Project.Models;

    public class Final_ProjectContext : DbContext
    {
        public Final_ProjectContext (DbContextOptions<Final_ProjectContext> options)
            : base(options)
        {
        }

    public DbSet<Services> Services { get; set; }
    public DbSet<Sub_Services> Sub_Services { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }
}
