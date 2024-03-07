using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ForrealServerBL.Models;

public partial class ForrealDbContext : DbContext
{
    public ForrealDbContext()
    {
    }

    public ForrealDbContext(DbContextOptions<ForrealDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Challenge> Challenges { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersChallenge> UsersChallenges { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=ForrealDB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Challenge>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Challeng__3214EC2703A47ACA");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Text).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC27A1187B76");

            entity.HasIndex(e => e.Email, "UC_Email").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.UserName).HasMaxLength(100);
            entity.Property(e => e.UserPswd).HasMaxLength(30);
        });

        modelBuilder.Entity<UsersChallenge>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users_Ch__3214EC27DC12A997");

            entity.ToTable("Users_Challenges");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ChallengeId).HasColumnName("ChallengeID");
            entity.Property(e => e.Media)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Challenge).WithMany(p => p.UsersChallenges)
                .HasForeignKey(d => d.ChallengeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Challenges_ChallangeID");

            entity.HasOne(d => d.User).WithMany(p => p.UsersChallenges)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Challenges_UserID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
