using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SeminarManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Seminar> Seminars { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Models.Type> Types { get; set; }
    }
}
