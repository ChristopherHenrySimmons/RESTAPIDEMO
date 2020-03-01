using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RESTAPIDEMO.Models
{
    public partial class DevelopmentUtilitiesV1Context : DbContext
    {
        public DevelopmentUtilitiesV1Context()
        {
        }

        public DevelopmentUtilitiesV1Context(DbContextOptions<DevelopmentUtilitiesV1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Commands> Commands { get; set; }
        public virtual DbSet<Exercises> Exercises { get; set; }
        public virtual DbSet<Problems> Problems { get; set; }
        public virtual DbSet<Resources> Resources { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:developmentutilities.database.windows.net,1433;Initial Catalog=DevelopmentUtilitiesV1;Persist Security Info=False;User ID=dev;Password=Password_21600681;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Commands>(entity =>
            {
                entity.Property(e => e.Command)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ConsoleType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Tile)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Exercises>(entity =>
            {
                entity.HasIndex(e => e.Exercise)
                    .HasName("UQ__Exercise__051A1072D4B36DF8")
                    .IsUnique();

                entity.Property(e => e.Exercise)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ExerciseLevel).HasMaxLength(50);

                entity.Property(e => e.ExpectedSolution).HasMaxLength(50);

                entity.Property(e => e.Langues).HasMaxLength(50);

                entity.Property(e => e.ProjectType).HasMaxLength(50);

                entity.Property(e => e.Solution).HasMaxLength(250);

                entity.Property(e => e.VarableData).HasMaxLength(50);
            });

            modelBuilder.Entity<Problems>(entity =>
            {
                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<Resources>(entity =>
            {
                entity.HasIndex(e => e.Title)
                    .HasName("UQ__Resource__2CB664DC2BA92795")
                    .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Langues).HasMaxLength(50);

                entity.Property(e => e.Link).HasMaxLength(250);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);
            });
        }
    }
}
