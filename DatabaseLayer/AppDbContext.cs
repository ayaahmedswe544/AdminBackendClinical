using DatabaseLayer.Models;
using DomainLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Test> Tests { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Appointment> appointments { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Diagnos> diagnos { get; set; }
        public DbSet<DiagnosMaster> DiagnosMaster { get; set; }
        public DbSet<Prescription> prescriptions { get; set; }
        public DbSet<VitalSign> vitalSigns { get; set; }
        public DbSet<VitalSignMaster> vitalSignMasters { get; set; }
        public DbSet<medicalExamination> medicalExaminations { get; set; }
        public DbSet<classificationMedicalExamination> classificationsMedicalExaminations { get; set; }
        public DbSet<saveExamination> saveExamination { get; set; }
        public DbSet<saveVitalSign> saveVitalSigns { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entity mappings here
            base.OnModelCreating(modelBuilder);
        }
    }
}
