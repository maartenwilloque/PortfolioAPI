using Microsoft.EntityFrameworkCore;
using portfolioapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolioapi
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext() { }
        public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options) { }

        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences {  get; set; }
        public DbSet<Knowledge> Knowledges { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectPTag> ProjectPTags { get; set; }
        public DbSet<PTag> Ptags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Education>().ToTable("Education");
            modelBuilder.Entity<Experience>().ToTable("Experience");
            modelBuilder.Entity<Knowledge>().ToTable("Knowledge");
            modelBuilder.Entity<Language>().ToTable("Language");
            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<ProjectPTag>().ToTable("ProjectPTag");
            modelBuilder.Entity<PTag>().ToTable("PTag");

            modelBuilder.Entity<ProjectPTag>()
                .HasKey(pt => new { pt.ProjectId, pt.PTagId });

            modelBuilder.Entity<ProjectPTag>()
                .HasOne(pt => pt.Project)
                .WithMany(p => p.Tags)
                .HasForeignKey(pt => pt.ProjectId);

            modelBuilder.Entity<ProjectPTag>()
                .HasOne(pt => pt.PTag)
                .WithMany()
                .HasForeignKey(pt => pt.PTagId);



        }
    }
}
