using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CRUD_MVC_socios_club.Models
{
    public partial class socios_club_dbContext : DbContext
    {
        public socios_club_dbContext()
        {
        }

        public socios_club_dbContext(DbContextOptions<socios_club_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SociosDatum> SociosData { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseMySql("server=localhost;port=3306;database=socios_club_db;uid=root;password=Clave943194_", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<SociosDatum>(entity =>
            {
                entity.ToTable("socios_data");

                entity.HasComment("En esta tabla almancenamos los datos de los socios ");

                entity.Property(e => e.Name).HasMaxLength(70);

                entity.Property(e => e.Type).HasMaxLength(45);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
