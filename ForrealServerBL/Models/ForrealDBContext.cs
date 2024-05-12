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

    public virtual DbSet<Friend> Friends { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersChallenge> UsersChallenges { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ForrealDB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Challenge>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Challeng__3214EC27BE435437");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Text).HasMaxLength(255);
        });

        modelBuilder.Entity<Friend>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Friends__3214EC274F9C3359");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.User1Id).HasColumnName("User1ID");
            entity.Property(e => e.User2Id).HasColumnName("User2ID");

            entity.HasOne(d => d.User1).WithMany(p => p.FriendUser1s)
                .HasForeignKey(d => d.User1Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Friends_User1ID");

            entity.HasOne(d => d.User2).WithMany(p => p.FriendUser2s)
                .HasForeignKey(d => d.User2Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Friends_User2ID");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Messages__3214EC27EAA56042");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Message1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Message");
            entity.Property(e => e.Time).HasColumnType("smalldatetime");
            entity.Property(e => e.UserChId).HasColumnName("UserChID");
            entity.Property(e => e.UserSentId).HasColumnName("UserSentID");

            entity.HasOne(d => d.UserCh).WithMany(p => p.Messages)
                .HasForeignKey(d => d.UserChId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Friends_UserChID");

            entity.HasOne(d => d.UserSent).WithMany(p => p.Messages)
                .HasForeignKey(d => d.UserSentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Friends_UserSentID");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC27ECA7C112");

            entity.HasIndex(e => e.Email, "UC_Email").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.UserName).HasMaxLength(100);
            entity.Property(e => e.UserPswd).HasMaxLength(30);
        });

        modelBuilder.Entity<UsersChallenge>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users_Ch__3214EC27719B361F");

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
