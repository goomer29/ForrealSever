using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ForrealSever.Models;

public partial class ForrealDbContext : DbContext
{
    public ForrealDbContext()
    {
    }

    public ForrealDbContext(DbContextOptions<ForrealDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Challange> Challanges { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersChallange> UsersChallanges { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=ForrealDB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Challange>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Challang__3214EC27329BF32B");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Text).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC275590443E");

            entity.HasIndex(e => e.Email, "UC_Email").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.UserName).HasMaxLength(100);
            entity.Property(e => e.UserPswd).HasMaxLength(30);
        });

        modelBuilder.Entity<UsersChallange>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users_Ch__3214EC275B70A18E");

            entity.ToTable("Users_Challanges");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ChallangeId).HasColumnName("ChallangeID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
