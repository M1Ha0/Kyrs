using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Kyrs.Model;

public partial class MykyrsContext : DbContext
{
    public MykyrsContext()
    {
        Database.EnsureCreated();
    }

    public MykyrsContext(DbContextOptions<MykyrsContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<Flight> Flights { get; set; }

    public virtual DbSet<FreePlace> FreePlaces { get; set; }

    public virtual DbSet<Passenger> Passengers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=Mykyrs.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Flight>(entity =>
        {
            entity.HasKey(e => e.NumberFlight);

            entity.ToTable("Flight");

            entity.Property(e => e.NumberFlight).ValueGeneratedNever();
            entity.Property(e => e.Price).HasColumnType("NUMERIC");
        });

        modelBuilder.Entity<FreePlace>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("FreePlace");

            entity.Property(e => e.FreePlace1).HasColumnName("FreePlace");

            entity.HasOne(d => d.NumberFlightNavigation).WithMany()
                .HasForeignKey(d => d.NumberFlight)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Passenger>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Passenger");

            entity.HasOne(d => d.NumberFlightNavigation).WithMany()
                .HasForeignKey(d => d.NumberFlight)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
