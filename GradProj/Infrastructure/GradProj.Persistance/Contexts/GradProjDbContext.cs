using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace GradProj.Persistance.Contexts
{
    public class GradProjDbContext : DbContext
    {
        public GradProjDbContext()
        {

        }
        public GradProjDbContext(DbContextOptions<GradProjDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<ToDo> Task { get; set; }
        public DbSet<TrackedProducts> TrackedProducts { get; set; }
        public DbSet<User_Tasks> User_Tasks { get; set; }
        public DbSet<UserEvents> User_Events { get; set; }
        public DbSet<UserTrackedProducts> UserTrackedProducts { get; set; }

    }
}
