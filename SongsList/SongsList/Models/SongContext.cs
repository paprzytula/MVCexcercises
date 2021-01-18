using Microsoft.EntityFrameworkCore;

namespace SongsList.Models
{
    public class SongContext : DbContext
    {
        public SongContext(DbContextOptions<SongContext> options) : base(options)
        {
        }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>().HasData(
                new Song
                {
                    SongId = 1,
                    Name = "Master of Puppets",
                    Year = 1986,
                    Rating = 5,
                    GenreId = "M"
                },
                new Song
                {
                    SongId = 2,
                    Name = "Wonderwall",
                    Year = 1995,
                    Rating = 4,
                    GenreId = "R"
                },
                 new Song
                 {
                     SongId = 3,
                     Name = "Loose Yourself",
                     Year = 2002,
                     Rating = 2,
                     GenreId="H"
                 }
                );
            modelBuilder.Entity<Genre>().HasData(
                new Genre
                {
                    GenreId = "M", Name="Metal"
                },
                new Genre
                {
                    GenreId="R", Name="Rock"
                },
                new Genre
                {
                    GenreId="C", Name="Classical"
                },
                new Genre
                {
                    GenreId = "H",
                    Name = "Hip-Hop"
                }
                );
        }
    }
}
