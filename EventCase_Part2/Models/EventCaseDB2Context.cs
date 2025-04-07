using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EventCase_Part2.Models
{
    public partial class EventCaseDB2Context : DbContext
    {
        public EventCaseDB2Context()
            : base("name=EventCaseDB2Context")
        {
        }

        public virtual DbSet<BookingSM> BookingSMs { get; set; }
        public virtual DbSet<Event_> Event_ { get; set; }
        public virtual DbSet<VenueSM> VenueSMs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event_>()
                .Property(e => e.EventName)
                .IsUnicode(false);

            modelBuilder.Entity<Event_>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Event_>()
                .HasMany(e => e.BookingSMs)
                .WithRequired(e => e.Event_)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VenueSM>()
                .Property(e => e.VenueName)
                .IsUnicode(false);

            modelBuilder.Entity<VenueSM>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<VenueSM>()
                .Property(e => e.Image_Url)
                .IsUnicode(false);

            modelBuilder.Entity<VenueSM>()
                .HasMany(e => e.BookingSMs)
                .WithRequired(e => e.VenueSM)
                .WillCascadeOnDelete(false);
        }
    }
}
