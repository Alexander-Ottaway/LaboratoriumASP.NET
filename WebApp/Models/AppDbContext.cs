using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

public class AppDbContext : DbContext
{
    public DbSet<ContactEntity> Contacts { get; set; }
    private string DbPath  { get; set; }

    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "contacts.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data source={DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactEntity>().HasData(
            new ContactEntity()
            {
                Id = 1,
                FirstName = "Bartek",
                LastName = "Kasperek",
                BirthDate = new DateOnly(2000, 10, 10),
                Email = "barti@gmail.com",
                PhoneNumber = "888111888",
                Created = DateTime.Now
            },
            new ContactEntity()
            {
                Id = 2,
                FirstName = "Norbert",
                LastName = "Kasperek",
                BirthDate = new DateOnly(2001, 11, 11),
                Email = "norbi@gmail.com",
                PhoneNumber = "111999111",
                Created = DateTime.Now
            }
        );
    }
}