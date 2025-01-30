using System;
using System.Collections.Generic;
using Distant.Models;
using Microsoft.EntityFrameworkCore;

namespace Distant.Context;

public partial class DimaBaseContext : DbContext
{
    public DimaBaseContext()
    {
    }

    public DimaBaseContext(DbContextOptions<DimaBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Applicant> Applicants { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<FormOfEducation> FormOfEducations { get; set; }

    public virtual DbSet<InputType> InputTypes { get; set; }

    public virtual DbSet<JobTitle> JobTitles { get; set; }

    public virtual DbSet<Speciality> Specialities { get; set; }

    public virtual DbSet<Statement> Statements { get; set; }

    public virtual DbSet<SystemOkko> SystemOkkos { get; set; }

    public virtual DbSet<YesNo> YesNos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=89.110.53.87:5522;Database=dima_base;Username=dima;password=dima");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Applicant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("applicants_pk");

            entity.ToTable("Applicants", "DemoDistant");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.Address).HasColumnType("character varying");
            entity.Property(e => e.ApplicantsCode).HasColumnName("Applicants_Code");
            entity.Property(e => e.DateOfBirth).HasColumnName("Date_Of_Birth");
            entity.Property(e => e.Email).HasColumnType("character varying");
            entity.Property(e => e.Fio)
                .HasColumnType("character varying")
                .HasColumnName("FIO");
            entity.Property(e => e.Passport).HasColumnType("character varying");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employees_pk");

            entity.ToTable("Employees", "DemoDistant");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.EmployeesId)
                .HasColumnType("character varying")
                .HasColumnName("Employees_ID");
            entity.Property(e => e.Fio)
                .HasColumnType("character varying")
                .HasColumnName("FIO");
            entity.Property(e => e.InputType).HasColumnName("Input_Type");
            entity.Property(e => e.JobTitle).HasColumnName("Job_Title");
            entity.Property(e => e.LastLogin).HasColumnName("Last_Login");
            entity.Property(e => e.Login).HasColumnType("character varying");
            entity.Property(e => e.Password).HasColumnType("character varying");

            entity.HasOne(d => d.InputTypeNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.InputType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employees_input_type_fk");

            entity.HasOne(d => d.JobTitleNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.JobTitle)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employees_job_title_fk");
        });

        modelBuilder.Entity<FormOfEducation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("form_of_education_pk");

            entity.ToTable("Form_Of_Education", "DemoDistant");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasColumnType("character varying");
        });

        modelBuilder.Entity<InputType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("input_type_pk");

            entity.ToTable("Input_Type", "DemoDistant");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasColumnType("character varying");
        });

        modelBuilder.Entity<JobTitle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("job_title_pk");

            entity.ToTable("Job_Title", "DemoDistant");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasColumnType("character varying");
        });

        modelBuilder.Entity<Speciality>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("speciality_pk");

            entity.ToTable("Speciality", "DemoDistant");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Code).HasColumnType("character varying");
            entity.Property(e => e.FormOfEducation).HasColumnName("Form_Of_Education");
            entity.Property(e => e.NameOfTheSspecialty)
                .HasColumnType("character varying")
                .HasColumnName("Name_Of_The_Sspecialty");
            entity.Property(e => e.NumberOfSeats).HasColumnName("Number_Of_Seats");

            entity.HasOne(d => d.FormOfEducationNavigation).WithMany(p => p.Specialities)
                .HasForeignKey(d => d.FormOfEducation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("speciality_form_of_education_fk");
        });

        modelBuilder.Entity<Statement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("statement_pk");

            entity.ToTable("Statement", "DemoDistant");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.ApplicantCode).HasColumnName("Applicant_Code");
            entity.Property(e => e.DiplomaOfEducation).HasColumnName("Diploma_Of_Education");
            entity.Property(e => e.NumberOfPoints).HasColumnName("Number_Of_Points");
            entity.Property(e => e.PersonalFileNumber)
                .HasColumnType("character varying")
                .HasColumnName("Personal_File_Number");
            entity.Property(e => e.SelectedSpecialties).HasColumnName("Selected_Specialties");
            entity.Property(e => e.SubmissionDate).HasColumnName("Submission_Date");
            entity.Property(e => e.SubmissionTime).HasColumnName("Submission_Time");

            entity.HasOne(d => d.DiplomaOfEducationNavigation).WithMany(p => p.StatementDiplomaOfEducationNavigations)
                .HasForeignKey(d => d.DiplomaOfEducation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("statement_yesno_fk_1");

            entity.HasOne(d => d.PassportNavigation).WithMany(p => p.StatementPassportNavigations)
                .HasForeignKey(d => d.Passport)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("statement_yesno_fk");

            entity.HasOne(d => d.SelectedSpecialtiesNavigation).WithMany(p => p.Statements)
                .HasForeignKey(d => d.SelectedSpecialties)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("statement_speciality_fk");
        });

        modelBuilder.Entity<SystemOkko>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("system_pk");

            entity.ToTable("SystemOkko", "DemoDistant");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ApplicantsId).HasColumnName("Applicants_ID");
            entity.Property(e => e.EmployeesId).HasColumnName("Employees_ID");
            entity.Property(e => e.StatementId).HasColumnName("Statement_ID");

            entity.HasOne(d => d.Applicants).WithMany(p => p.SystemOkkos)
                .HasForeignKey(d => d.ApplicantsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("system_applicants_fk");

            entity.HasOne(d => d.Employees).WithMany(p => p.SystemOkkos)
                .HasForeignKey(d => d.EmployeesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("system_employees_fk");

            entity.HasOne(d => d.Statement).WithMany(p => p.SystemOkkos)
                .HasForeignKey(d => d.StatementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("system_statement_fk");
        });

        modelBuilder.Entity<YesNo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("yesno_pk");

            entity.ToTable("YesNo", "DemoDistant");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasColumnType("character varying");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
