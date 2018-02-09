using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ResortDbContext : DbContext
    {
        public ResortDbContext(DbContextOptions<ResortDbContext> options) : base(options)
        {
        }
        public DbSet<ResortPost> ResortPosts { get; set; }
    }

}
