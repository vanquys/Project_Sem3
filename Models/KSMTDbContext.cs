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
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Competition> Competitions { get; set; }
        public virtual DbSet<DataQuuestion> DataQuuestions { get; set; }
        public virtual DbSet<FAQ> FAQs { get; set; }
        public virtual DbSet<Register> Registers { get; set; }
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
                .HasMany(e => e.AnswerResults)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Registrations)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.RollNo);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.UserCompetitions)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Competition>()
                .HasMany(e => e.DataQuuestions)
                .WithRequired(e => e.Competition)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Competition>()
                .HasMany(e => e.UserCompetitions)
                .WithRequired(e => e.Competition)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Register>()
                .Property(e => e.Image)
                .IsUnicode(false);
        }
    }
}
