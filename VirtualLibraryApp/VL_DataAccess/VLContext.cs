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
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookReview> BookReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookReview>()
                .Property(br => br.Rate)
                .HasConversion<int>();
            //modelBuilder.Entity<Book>()
            //    .HasKey(b => b.Id);

        }

    }
}
