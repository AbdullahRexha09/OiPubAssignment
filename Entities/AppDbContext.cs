using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OiPubAssignment.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Paper> Paper { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<PaperAuthor> PaperAuthor { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(new Author[]
            {
                new Author{ Id = Guid.Parse("58CA7A2D-EF9D-47DA-9BA2-2A27B76DA85C"),
                    FirstName = "Abdullah",
                    LastName = "Rexha"},
                new Author{ Id = Guid.Parse("68CA7A2D-EF9D-47DA-9BA2-2A27B76DA85C"),
                    FirstName = "Shpetim",
                    LastName = "Rexha"},
            });

        }
    }

}
