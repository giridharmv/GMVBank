using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System;
using GMVBank.Models;

namespace GMVBank.DB
{
    public class Database: DbContext
    {
        public Database() { }

        // DbSet for Users table
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Get the project root directory (going up from bin/Debug/net10.0)
            string projectRoot = Directory.GetCurrentDirectory();

            // Navigate to the actual project root (when running from bin folder)
            while (!File.Exists(Path.Combine(projectRoot, "GMVBank.csproj")) && 
                   Directory.GetParent(projectRoot) != null)
            {
                projectRoot = Directory.GetParent(projectRoot).FullName;
            }

            // Create Database folder if it doesn't exist
            string databaseFolder = Path.Combine(projectRoot, "Database");
            Directory.CreateDirectory(databaseFolder);

            // Set the database file path
            string dbPath = Path.Combine(databaseFolder, "GMVBank.db");

            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure User entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.CustomerID);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.AccountNumber).IsRequired();
                entity.HasIndex(e => e.AccountNumber).IsUnique();
                entity.Property(e => e.AccountType).IsRequired();
                entity.Property(e => e.Gender).IsRequired();
                entity.Property(e => e.CreatedAt).IsRequired();
            });
        }
    }
}
