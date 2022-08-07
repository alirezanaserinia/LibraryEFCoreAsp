using BehKhaan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaan.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Book
            modelBuilder.Entity<Book>().HasKey(b => b.Id);
            modelBuilder.Entity<Book>().Property(b => b.Name).HasMaxLength(50);

            // User
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().Property(u => u.UserName).HasMaxLength(50);
            modelBuilder.Entity<User>().Property(u => u.FullName).HasMaxLength(80);

            // Shelf
            modelBuilder.Entity<Shelf>().HasKey(s => s.Id);
            modelBuilder.Entity<Shelf>().Property(s => s.Name).HasMaxLength(50);
            modelBuilder.Entity<Shelf>().HasOne(s => s.User).WithMany().HasForeignKey(s => s.UserId);
            modelBuilder.Entity<Shelf>().Navigation(s => s.User).AutoInclude();


            // Book_Shelf
            modelBuilder.Entity<Book_Shelf>().HasKey(bs => new {bs.BookId, bs.ShelfId});
            modelBuilder.Entity<Book_Shelf>().HasOne(bs => bs.Book).WithMany().HasForeignKey(bs => bs.BookId);
            modelBuilder.Entity<Book_Shelf>().HasOne(bs => bs.Shelf).WithMany().HasForeignKey(bs => bs.ShelfId);
            modelBuilder.Entity<Book_Shelf>().Navigation(bs => bs.Book).AutoInclude();
            modelBuilder.Entity<Book_Shelf>().Navigation(bs => bs.Shelf).AutoInclude();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Shelf> Shelfs { get; set; }
        public DbSet<Book_Shelf> Books_Shelfs { get; set; }
    }
}
