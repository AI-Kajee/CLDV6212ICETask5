using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoD_Command_Center.Models;

public partial class CoDCommandCenterContext : DbContext
{
    public CoDCommandCenterContext()
    {
    }

    public CoDCommandCenterContext(DbContextOptions<CoDCommandCenterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Codevent> Codevents { get; set; }

    public virtual DbSet<LeaderBoard> LeaderBoards { get; set; }

    public virtual DbSet<NewsAndUpdate> NewsAndUpdates { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<User1> User1s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-IKNUD48;Initial Catalog=CoD_Command_Center;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Codevent>(entity =>
        {
            entity.HasKey(e => e.EId).HasName("PK__CODevent__3EB42142FB1787FA");

            entity.ToTable("CODevents");

            entity.Property(e => e.EId).HasColumnName("e_Id");
            entity.Property(e => e.EEndDate).HasColumnName("e_EndDate");
            entity.Property(e => e.EStartDate).HasColumnName("e_StartDate");
            entity.Property(e => e.EventDetails)
                .IsUnicode(false)
                .HasColumnName("eventDetails");
            entity.Property(e => e.EventName)
                .IsUnicode(false)
                .HasColumnName("eventName");
        });

        modelBuilder.Entity<LeaderBoard>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__LeaderBo__CB9A1CDFAA5081F2");

            entity.ToTable("LeaderBoard");

            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("userID");
            entity.Property(e => e.KillCount).HasColumnName("killCount");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.LeaderBoards)
                .HasForeignKey(d => d.UserName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LeaderBoa__UserN__3C69FB99");
        });

        modelBuilder.Entity<NewsAndUpdate>(entity =>
        {
            entity.HasKey(e => e.AId).HasName("PK__NewsAndU__5667CED2E0599269");

            entity.Property(e => e.AId).HasColumnName("a_Id");
            entity.Property(e => e.ACreatedAt).HasColumnName("a_CreatedAt");
            entity.Property(e => e.AUpdatedAt).HasColumnName("a_UpdatedAt");
            entity.Property(e => e.ArticleDescription)
                .IsUnicode(false)
                .HasColumnName("articleDescription");
            entity.Property(e => e.ArticleName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("articleName");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__post__3214EC07C91411E2");

            entity.ToTable("post");

            entity.Property(e => e.BlogBody)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("blog_body");
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt");
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.TeamId).HasName("PK__Team__5ED7534AB1DA26D6");

            entity.ToTable("Team");

            entity.Property(e => e.TeamId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("teamID");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.NumTrophees).HasColumnName("numTrophees");
            entity.Property(e => e.Ranking).HasColumnName("ranking");
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("role");
            entity.Property(e => e.TeamName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("teamName");
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.Teams)
                .HasForeignKey(d => d.UserName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Team__UserName__398D8EEE");
        });

        modelBuilder.Entity<User1>(entity =>
        {
            entity.HasKey(e => e.UserName).HasName("PK__User1__C9F284575469EA73");

            entity.ToTable("User1");

            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Badge)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("badge");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("emailAddress");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.KillCount).HasColumnName("killCount");
            entity.Property(e => e.KnockoutRatio)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("knockoutRatio");
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.NickName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nickName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
