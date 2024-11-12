using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

public class AppDbContext : DbContext
{
    public DbSet<ContactEntity> Contacts { get; set; }
    public DbSet<OrganizationEntity> Organizations { get; set; }
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
        modelBuilder.Entity<ContactEntity>()
            .HasOne<OrganizationEntity>(c => c.Organization)
            .WithMany(o => o.Contacts)
            .HasForeignKey(c => c.OrganizationId);

        modelBuilder.Entity<OrganizationEntity>()
            .ToTable("organization")
            .HasData(
                new OrganizationEntity()
                {
                    Id = 101,
                    Name = "WSEI",
                    NIP = "68243654983",
                    REGON = "6725725725"
                },
                new OrganizationEntity()
                {
                    Id = 102,
                    Name = "UEK",
                    NIP = "972570370923",
                    REGON = "5325632570937"
                }
            );

        modelBuilder.Entity<OrganizationEntity>()
            .OwnsOne(o => o.Address)
            .HasData(
                new { City = "Kraków", Street = "św. Filipa 17", OrganizationEntityId = 101 },
                new { City = "Warszawa", Street = "św. Jana 16", OrganizationEntityId = 102 }
            );
        
        modelBuilder.Entity<ContactEntity>().HasData(
            new ContactEntity()
            {
                Id = 1,
                FirstName = "Bartek",
                LastName = "Kasperek",
                BirthDate = new DateOnly(2000, 10, 10),
                Email = "barti@gmail.com",
                PhoneNumber = "888111888",
                Created = DateTime.Now,
                OrganizationId = 101
            },
            new ContactEntity()
            {
                Id = 2,
                FirstName = "Norbert",
                LastName = "Kasperek",
                BirthDate = new DateOnly(2001, 11, 11),
                Email = "norbi@gmail.com",
                PhoneNumber = "111999111",
                Created = DateTime.Now,
                OrganizationId = 102
            }
        );
    }
}