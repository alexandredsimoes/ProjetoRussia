using Microsoft.EntityFrameworkCore;
using Models;

namespace CRUD.Context
{
    public class TimeContext : DbContext
    {
        public TimeContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Time>().ToTable("TIME")
                .HasMany(c => c.Jogadores)
                .WithOne(c => c.Time);
            modelBuilder.Entity<Jogador>().ToTable("JOGADOR");
            modelBuilder.Entity<Ficha>().ToTable("FICHA");
            modelBuilder.Entity<Jogo>().ToTable("JOGO");
            modelBuilder.Entity<Gol>().ToTable("GOL");

            modelBuilder.Entity<Jogo>()
                .HasOne(c => c.Time_1)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Jogo>()
                .HasOne(c => c.Time_2)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Gol>()
                .HasOne(c => c.Time)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);




            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Time> Times { get; set; }
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Ficha> Fichas { get; set; }
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Gol> Gols { get; set; }
    }
}
