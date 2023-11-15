using System;
using Budgeteer_Angular.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Budgeteer_Angular.Data
{
    public partial class AppContext : DbContext
    {
        public AppContext()
        {
        }

        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Frequency> Frequencies { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Income> Incomes { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=budget_app;Username=postgres;Password=super1731");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "English_United States.1252");

            modelBuilder.Entity<Frequency>(entity =>
            {
                entity.ToTable("frequency", "development");

                entity.Property(e => e.FrequencyId)
                    .ValueGeneratedNever()
                    .HasColumnName("frequency_id");

                entity.Property(e => e.FrequencyType)
                    .HasColumnType("character varying")
                    .HasColumnName("frequency_type");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("groups", "development");

                entity.Property(e => e.GroupId)
                    .ValueGeneratedNever()
                    .HasColumnName("group_id");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("group_name");
            });

            modelBuilder.Entity<Income>(entity =>
            {
                entity.ToTable("income", "development");

                entity.Property(e => e.IncomeId)
                    .ValueGeneratedNever()
                    .HasColumnName("income_id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.FrequencyId).HasColumnName("frequency_id");

                entity.Property(e => e.Source)
                    .HasColumnType("character varying")
                    .HasColumnName("source");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Frequency)
                    .WithMany(p => p.Incomes)
                    .HasForeignKey(d => d.FrequencyId)
                    .HasConstraintName("income_frequency_fk");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Incomes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("income_user_fk");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasKey(e => e.MembersId)
                    .HasName("members_pk");

                entity.ToTable("members", "development");

                entity.Property(e => e.MembersId)
                    .ValueGeneratedNever()
                    .HasColumnName("members_id");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("members_group_fk");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("members_user_fk");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users", "development");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.EmailAddress)
                    .HasColumnType("character varying")
                    .HasColumnName("email_address");

                entity.Property(e => e.FirstName)
                    .HasColumnType("character varying")
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasColumnType("character varying")
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .HasColumnType("character varying")
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
