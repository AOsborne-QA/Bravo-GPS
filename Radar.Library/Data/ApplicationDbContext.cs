using Microsoft.EntityFrameworkCore;
using Radar.Library.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Radar.Library.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        
    }
}
