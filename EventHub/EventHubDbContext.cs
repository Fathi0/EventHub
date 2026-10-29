using EventHub.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EventHub
{
    public class EventHubDbContext:DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Organizer>()
                .HasOne(O => O.organizerProfile)
                .WithOne(P => P.organizer)
                .HasForeignKey<OrganizerProfile>(P => P.OrganizerId)
                .IsRequired();
            modelBuilder.Entity<Organizer>()
                .HasMany(O => O.events)
                .WithOne(E => E.organizer)
                .HasForeignKey(E => E.OrganizerId)
                .IsRequired();
            modelBuilder.Entity<Attendee>()
                .HasOne(A => A.badge)
                .WithOne(B => B.attendee)
                .HasForeignKey<Badge>(B => B.AttendeeId)
                .IsRequired();
           
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = .;Database = EventHub;Trusted_Connection=true; TrustServerCertificate=true;");
        }

       public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<OrganizerProfile> OrganizerProfiles { get; set; }
    }
}
