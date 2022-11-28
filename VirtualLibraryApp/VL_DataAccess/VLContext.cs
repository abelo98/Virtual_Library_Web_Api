using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VL_DataAccess.Models;

namespace VL_DataAccess
{
    public class VLContext : DbContext
    {
        public VLContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<LibraryUser> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookReview> BookReviews { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasKey(b => b.ISBN);
            modelBuilder.Entity<Book>().Ignore(b => b.Id);

            modelBuilder.Entity<BookReview>()
                .Property(br => br.Rate)
                .HasConversion<int>();

            modelBuilder.Entity<Subscription>()
                .HasKey(s => new { s.LibraryUserId, s.AuthorId });
            modelBuilder.Entity<Subscription>()
                .Ignore(s => s.Id);



        }

    }
}
