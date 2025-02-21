using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RetechAPI.Models;
using System;

namespace RetechAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
    }
    
}
