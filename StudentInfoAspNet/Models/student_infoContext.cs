using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace StudentInfoAspNet.Models
{
    public partial class StudentInfoContext : DbContext
    {
        private static IConfiguration _dbConfiguration;
        private string _connectionString;
        public StudentInfoContext()
        {
            _dbConfiguration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = _dbConfiguration.GetConnectionString("DatabaseConnectionString");
        }

        public StudentInfoContext(DbContextOptions<StudentInfoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Students> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=qwert123;database=student_info");
                optionsBuilder.UseMySQL(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Groups>(entity =>
            {
                entity.ToTable("groups");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CuratorFamily)
                    .IsRequired()
                    .HasColumnName("curator_family")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.AverageScore)
                    .IsRequired()
                    .HasColumnName("average_score")
                    .HasColumnType("double");
                
                entity.Property(e => e.TitleDirection)
                    .IsRequired()
                    .HasColumnName("title_direction")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.ToTable("students");

                entity.HasIndex(e => e.GroupId)
                    .HasName("FK1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GroupId)
                    .HasColumnName("group_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.SecondName)
                    .IsRequired()
                    .HasColumnName("second_name")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'0'");
                
                entity.Property(e => e.AverageScore)
                    .IsRequired()
                    .HasColumnName("average_score")
                    .HasColumnType("double");
                
                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK1")
                    .IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
