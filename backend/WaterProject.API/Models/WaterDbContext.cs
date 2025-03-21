using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WaterProject.API.Models;
public class WaterDbContext : DbContext
{
    public WaterDbContext(DbContextOptions<WaterDbContext> options) : base(options)
    {
        
    }

    public DbSet<Project> Projects { get; set; }  // Ensure this matches your database
}

