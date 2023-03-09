using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Project_Sem3.Models
{
    public partial class KSMTDbContext : DbContext
    {
        public KSMTDbContext()
            : base("name=KSMT")
        {
        }

        public virtual DbSet<AnswerResult> AnswerResults { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Competition> Competitions { get; set; }
        public virtual DbSet<FAQ> FAQs { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
        public virtual DbSet<Support> Supports { get; set; }
        public virtual DbSet<UserCompetition> UserCompetitions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Registrations)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.UserCompetitions)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Competition>()
                .HasMany(e => e.AnswerResults)
                .WithRequired(e => e.Competition)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Competition>()
                .HasMany(e => e.UserCompetitions)
                .WithRequired(e => e.Competition)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Registration>()
                .HasMany(e => e.AnswerResults)
                .WithRequired(e => e.Registration)
                .HasForeignKey(e => e.IdRegistratedUser)
                .WillCascadeOnDelete(false);
        }
    }
}
