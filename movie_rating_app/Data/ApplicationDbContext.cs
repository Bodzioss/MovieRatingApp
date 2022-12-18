using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using movie_rating_app.Models;

namespace movie_rating_app.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<Favourite> Favourites { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<MoviePerson> MoviePeople { get; set; } = null!;
        public virtual DbSet<Nationality> Nationalities { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.FirstName).HasMaxLength(256);

                entity.Property(e => e.LastName).HasMaxLength(256);

                entity.Property(e => e.PersonName).HasMaxLength(256);

                entity.HasOne(d => d.Nationality)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.NationalityId)
                    .HasConstraintName("FK_Creators_Nationalities");
            });

            modelBuilder.Entity<Favourite>(entity =>
            {
                entity.HasIndex(e => e.MovieId, "IX_Favourites_MovieId");

                entity.HasIndex(e => e.UserId, "IX_Favourites_UserId");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Favourites)
                    .HasForeignKey(d => d.MovieId);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(256);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK_Movies_GenreId");
            });

            modelBuilder.Entity<MoviePerson>(entity =>
            {
                entity.HasIndex(e => e.PersonId, "IX_MovieCreators_CreatorId");

                entity.HasIndex(e => e.MovieId, "IX_MovieCreators_MovieId");

                entity.HasIndex(e => e.RoleId, "IX_MovieCreators_RoleId");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.MoviePeople)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovieCreators_Creators1");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MoviePeople)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovieCreators_Movies1");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.MoviePeople)
                    .HasForeignKey(d => d.RoleId);
            });


            modelBuilder.Entity<Nationality>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(256);
            });


            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasIndex(e => e.MovieId, "IX_Reviews_MovieId");

                entity.HasIndex(e => e.UserId, "IX_Reviews_UserId");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.MovieId);

            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(256);
            });

        }
    }
}