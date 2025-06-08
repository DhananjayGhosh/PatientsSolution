using Microsoft.EntityFrameworkCore;

namespace PatientAPI.Infrastructure.DbEntity
{
    public partial class PatientAPIDbContext : DbContext
    {
        public PatientAPIDbContext()
        {
        }

        public PatientAPIDbContext(DbContextOptions<PatientAPIDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppointTable> AppointTables { get; set; } = null!;
        public virtual DbSet<PersonalInfo> PersonalInfos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppointTable>(entity =>
            {
                entity.ToTable("AppointTable");

                entity.Property(e => e.AppointDate).HasColumnType("date");

                entity.Property(e => e.AutoId)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Auto_Id");

                entity.Property(e => e.CreatedOn).HasColumnType("date");

                entity.Property(e => e.Department)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DoctorId)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.DoctorName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("date");

                entity.HasOne(d => d.Auto)
                    .WithMany(p => p.AppointTableAutos)
                    .HasForeignKey(d => d.AutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppointTable_PersonalInfo_AutoId");

                entity.HasOne(d => d.PhoneNumberNavigation)
                    .WithMany(p => p.AppointTablePhoneNumberNavigations)
                    .HasPrincipalKey(p => p.PhoneNumber)
                    .HasForeignKey(d => d.PhoneNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<PersonalInfo>(entity =>
            {
                entity.ToTable("PersonalInfo");

                entity.HasIndex(e => e.PhoneNumber, "UQ__Personal__85FB4E3815729F61")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
