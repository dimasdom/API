using API.Models;
using Microsoft.EntityFrameworkCore;
using System;


namespace API.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
           
        }
        public DbSet<Activity> Activities { get; set; }
    }
}
