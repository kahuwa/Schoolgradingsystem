using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GradingSystems.Models
{
    public partial class SchoolgradingsystemContext : DbContext
    {
        public SchoolgradingsystemContext()
        {
        }

        public SchoolgradingsystemContext(DbContextOptions<SchoolgradingsystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CriteriaToSubmission> CriteriaToSubmissions { get; set; } = null!;
        public virtual DbSet<Criterion> Criteria { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserSubmission> UserSubmissions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           

                optionsBuilder.UseNpgsql("Host=localhost;Database=schoolgradingsystem;Username=postgres;Password=1234");
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CriteriaToSubmission>(entity =>
            {
                entity.HasKey(e => new { e.SubmissionId, e.CriteriaId, e.TeacherId })
                    .HasName("criteria_to_submissions_pkey");

                entity.ToTable("criteria_to_submissions", "gradingsystem");

                entity.Property(e => e.SubmissionId).HasColumnName("submission_id");

                entity.Property(e => e.CriteriaId).HasColumnName("criteria_id");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.Property(e => e.CommentTeacher)
                    .HasColumnType("character varying")
                    .HasColumnName("comment_teacher");

                entity.Property(e => e.Grade).HasColumnName("grade");

                entity.HasOne(d => d.Criteria)
                    .WithMany(p => p.CriteriaToSubmissions)
                    .HasForeignKey(d => d.CriteriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_criteria");

                entity.HasOne(d => d.Submission)
                    .WithMany(p => p.CriteriaToSubmissions)
                    .HasForeignKey(d => d.SubmissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_submission");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.CriteriaToSubmissions)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_teacher");
            });

            modelBuilder.Entity<Criterion>(entity =>
            {
                entity.ToTable("criteria", "gradingsystem");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Criteria)
                    .HasColumnType("character varying")
                    .HasColumnName("criteria");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles", "gradingsystem");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Roletype)
                    .HasColumnType("character varying")
                    .HasColumnName("roletype");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users", "gradingsystem");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Password)
                    .HasColumnType("character varying")
                    .HasColumnName("password");

                entity.Property(e => e.RolesId).HasColumnName("roles_id");

                entity.Property(e => e.Username)
                    .HasColumnType("character varying")
                    .HasColumnName("username");

                entity.HasOne(d => d.Roles)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RolesId)
                    .HasConstraintName("fk_roles");
            });

            modelBuilder.Entity<UserSubmission>(entity =>
            {
                entity.ToTable("user_submissions", "gradingsystem");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Github)
                    .HasColumnType("character varying")
                    .HasColumnName("github");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSubmissions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_user");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
