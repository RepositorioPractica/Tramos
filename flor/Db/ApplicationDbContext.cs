using flor.Entities;
using Microsoft.EntityFrameworkCore;

namespace flor.Db
{
    public class ApplicationDbContext  : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        public DbSet<Tramo> Tramos { get; set; }
        public DbSet<Geometria> Geometrias { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Tramo>().ToTable("Tramo");

            modelBuilder.Entity<Geometria>().HasKey(j => j.Id);
           
            //modelBuilder.Properties<int>().where(p => p.name.startswith("Id")).Configure(p => p.IsKey());

           /* modelBuilder.Entity<Geometria>().ToTable("Geometria")
                .HasOne(t => t.Tramo)
                .WithMany(b => b.Geometrias)
                 .HasForeignKey(p => p.fk_tramo);
            // .UsingEntity<Tramo>().HasKey(c => new {})
           */


              modelBuilder.Entity<Geometria>()
                  .HasOne(p => p.tramo)
                  .WithMany(b => b.Geometrias)
                  .HasForeignKey(p => p.TramoId);


        }

    }
}
