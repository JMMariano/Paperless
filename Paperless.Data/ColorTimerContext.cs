﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Microsoft.EntityFrameworkCore;
using Paperless.Models;

namespace Paperless.Data
{
    public partial class ColorTimerContext : DbContext
    {
        public ColorTimerContext()
        {
        }

        public ColorTimerContext(DbContextOptions<ColorTimerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ColorTimer> ColorTimers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ColorTimer>(entity =>
            {
                entity.ToTable("ColorTimer");

                // Primary key of ColorTimer table is not exposed to the class since it is auto-incremented when a ColorTimer is created
                entity.Property<int>("Id");

                entity.HasKey("Id");

                entity.Property(e => e.ColorHexCode).HasMaxLength(7);

                entity.Property(e => e.Name).HasMaxLength(15);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}