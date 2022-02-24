using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace NewShoreAPI.Entities
{
    public partial class NewShoreContext : DbContext
    {
        public NewShoreContext()
        {
        }

        public NewShoreContext(DbContextOptions<NewShoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Journey> Journeys { get; set; }
        public virtual DbSet<JourneyFlight> JourneyFlights { get; set; }
        public virtual DbSet<Transport> Transports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=NewShore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.HasKey(e => e.IdFlight)
                    .HasName("PK__tmp_ms_x__76B7C0C942A60332");

                entity.ToTable("Flight");

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Origin)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdTransportNavigation)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(d => d.IdTransport)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Flight_ToTransport");
            });

            modelBuilder.Entity<Journey>(entity =>
            {
                entity.HasKey(e => e.IdJourney)
                    .HasName("PK__Journey__22DE1A156B164369");

                entity.ToTable("Journey");

                entity.Property(e => e.Destination)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Origin)
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JourneyFlight>(entity =>
            {
                entity.HasKey(e => e.IdJourneyFlights)
                    .HasName("PK__JorneyFl__64CC5CE5A32AD2CF");

                entity.HasOne(d => d.IdJourneyNavigation)
                    .WithMany(p => p.JourneyFlights)
                    .HasForeignKey(d => d.IdJourney)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JourneyFlights_ToJourney");
            });

            modelBuilder.Entity<Transport>(entity =>
            {
                entity.HasKey(e => e.IdTransport)
                    .HasName("PK__Table__21525EC092371F93");

                entity.ToTable("Transport");

                entity.Property(e => e.FlightCarrier)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.FlightNumber)
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
