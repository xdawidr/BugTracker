using BugTracker.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Persistance
{
    public static class Seed
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(
                new Project() { Id = 1, Name = "First project", Description="Example first project", CreatedAt = DateTime.Now });

            modelBuilder.Entity<Bug>().HasData(
                new Bug()
                {
                    Id = 1,
                    ProjectId = 1,
                    Name = "First bug",
                    CreatedAt = DateTime.Now,
                    Description = "This is first bug",
                    Environment = "DEV1"
                });
        }
    }
}
