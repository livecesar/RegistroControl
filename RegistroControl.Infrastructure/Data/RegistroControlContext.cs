using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RegistroControl.Core.Entities;

#nullable disable

namespace RegistroControl.Infrastructure.Data
{
    public partial class RegistroControlContext : DbContext
    {
        public RegistroControlContext()
        {
        }

        public RegistroControlContext(DbContextOptions<RegistroControlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseStudent> CourseStudents { get; set; }
        public virtual DbSet<DniType> DniTypes { get; set; }
        public virtual DbSet<EventLog> EventLogs { get; set; }
        public virtual DbSet<EventLogType> EventLogTypes { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<SystemUser> SystemUsers { get; set; }
        public virtual DbSet<SystemUserType> SystemUserTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.HasKey(e => e.AdminId)
                    .HasName("PK__Administ__719FE48835270963");

                entity.ToTable("Administrator");

                entity.Property(e => e.AdminAddress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AdminName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AdminSurname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.Cellphone)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DniNumber)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Administrators)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CITY_ADMIN");

                entity.HasOne(d => d.DniType)
                    .WithMany(p => p.Administrators)
                    .HasForeignKey(d => d.DniTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DNITYPE_ADMIN");

                entity.HasOne(d => d.SystemUser)
                    .WithMany(p => p.Administrators)
                    .HasForeignKey(d => d.SystemUserId)
                    .HasConstraintName("FK_SYSTEMUSER_ADMINISTRATOR");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_DEPARTMENT_CITY");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<CourseStudent>(entity =>
            {
                entity.ToTable("CourseStudent");

                entity.Property(e => e.RelateDate).HasColumnType("date");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseStudents)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COURSESTUDENT_COURSE");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.CourseStudents)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COURSESTUDENT_STUDENT");
            });

            modelBuilder.Entity<DniType>(entity =>
            {
                entity.HasKey(e => e.DniId)
                    .HasName("PK__DniType__4FDF83222C8BF95A");

                entity.ToTable("DniType");

                entity.Property(e => e.DniName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EventLog>(entity =>
            {
                entity.ToTable("EventLog");

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.SysUser)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.EventLogType)
                    .WithMany(p => p.EventLogs)
                    .HasForeignKey(d => d.EventLogTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EVENTLOGTYPE_ENETLOG");

                entity.HasOne(d => d.SysUserType)
                    .WithMany(p => p.EventLogs)
                    .HasForeignKey(d => d.SysUserTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SYSUSERTYPE_ENETLOG");
            });

            modelBuilder.Entity<EventLogType>(entity =>
            {
                entity.ToTable("EventLogType");

                entity.Property(e => e.EventTypeName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.Cellphone)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DniNumber)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StudentAddress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StudentName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StudentSurname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CITY_STUDENT");

                entity.HasOne(d => d.DniType)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.DniTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DNITYPE_STUDENT");

                entity.HasOne(d => d.SystemUser)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.SystemUserId)
                    .HasConstraintName("FK_SYSTEMUSER_STUDENT");
            });

            modelBuilder.Entity<SystemUser>(entity =>
            {
                entity.ToTable("SystemUser");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.SysUserType)
                    .WithMany(p => p.SystemUsers)
                    .HasForeignKey(d => d.SysUserTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SYSUSER_SYSTEMUSERTYPE");
            });

            modelBuilder.Entity<SystemUserType>(entity =>
            {
                entity.HasKey(e => e.UserTypeId)
                    .HasName("PK__SystemUs__40D2D816201CF445");

                entity.ToTable("SystemUserType");

                entity.Property(e => e.UserTypeName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

        }

    }
}
