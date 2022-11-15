using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using movie_rating_app.Models;

namespace movie_rating_app.Data
{
    public partial class aspnetmovie_rating_appContext : IdentityDbContext<ApplicationUser>
    {
        public aspnetmovie_rating_appContext()
        {
        }

        public aspnetmovie_rating_appContext(DbContextOptions<aspnetmovie_rating_appContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; } = null!;
        public virtual DbSet<Creator> Creators { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<MoviesCast> MoviesCasts { get; set; } = null!;
        public virtual DbSet<Nationality> Nationalities { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-AMGTN3U;Initial Catalog=aspnet-movie_rating_app;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.FirstName).HasMaxLength(256);

                entity.Property(e => e.LastName).HasMaxLength(256);

                entity.Property(e => e.Nationality).HasMaxLength(256);

                entity.Property(e => e.RoleName).HasMaxLength(256);

                entity.HasOne(d => d.NationalityNavigation)
                    .WithMany(p => p.Actors)
                    .HasForeignKey(d => d.Nationality)
                    .HasConstraintName("FK_Actors_Nationalities");
            });


            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.Property(e => e.Name).HasMaxLength(256);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Genre).HasMaxLength(256);

                entity.HasOne(d => d.GenreNavigation)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.Genre)
                    .HasConstraintName("FK_Movies_Movies");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Movie)
                    .HasPrincipalKey<MoviesCast>(p => p.MovieId)
                    .HasForeignKey<Movie>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Movies_MoviesCasts");

                entity.HasMany(d => d.Creators)
                    .WithMany(p => p.Movies)
                    .UsingEntity<Dictionary<string, object>>(
                        "MovieCreator",
                        l => l.HasOne<Creator>().WithMany().HasForeignKey("CreatorId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_MovieCreators_Creators"),
                        r => r.HasOne<Movie>().WithMany().HasForeignKey("MovieId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_MovieCreators_Movies"),
                        j =>
                        {
                            j.HasKey("MovieId", "CreatorId").HasName("PK_MovieCreators_1");

                            j.ToTable("MovieCreators");
                        });
            });

            modelBuilder.Entity<MoviesCast>(entity =>
            {
                entity.HasKey(e => new { e.MovieId, e.ActorId })
                    .HasName("PK_MoviesCast");

                entity.HasIndex(e => e.MovieId, "IX_MoviesCast")
                    .IsUnique();

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.MoviesCasts)
                    .HasForeignKey(d => d.ActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MoviesCasts_Actors");
            });

            modelBuilder.Entity<Nationality>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.Property(e => e.Name).HasMaxLength(256);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.MovieId });

                entity.HasIndex(e => e.MovieId, "IX_Reviews_MovieId");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.MovieId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId);
            });

            base.OnModelCreating(modelBuilder);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
