using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductivityAppV2.Models;

namespace ProductivityAppV2.Data
{

    public class TaskDbContext : DbContext
    {
        public DbSet<TaskModel> Tasks { get; set; }

        public DbSet<Day> Days { get; set; }

        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }





    }
}
