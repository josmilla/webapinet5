﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Net5.Deployment.API.Infrastructure.Data.Contexts.Configurations;
using Net5.Deployment.API.Infrastructure.Data.Entities;
using System;
#nullable disable

#nullable disable

namespace Net5.Deployment.API.Infrastructure.Data.Contexts
{
    public partial class AlumnoContext : DbContext
    {
        public AlumnoContext()
        {
        }

        public AlumnoContext(DbContextOptions<AlumnoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumno { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.ApplyConfiguration(new Configurations.AlumnoConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}