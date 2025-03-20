using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Skeleton.Domain.Entities;
using Skeleton.Infrastructure.Extensions;

namespace Skeleton.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<UserEntity, RoleEntity, string>(options)
{
    public DbSet<CountryEntity> Countries { get; set; }
    public DbSet<ItemCategoryEntity> ItemCategories { get; set; }
    public DbSet<ItemEntity> Items { get; set; }
    public DbSet<UserNotificationEntity> UserNotifications { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region User

        var adminRole = new RoleEntity
            { Id = "61c697cb-ed25-4685-9030-45693a0ce433", Name = "Admin", NormalizedName = "ADMIN" };

        builder.Entity<RoleEntity>().HasData(adminRole);

        // Seed users
        var hasher = new PasswordHasher<UserEntity>();

        var adminUser = new UserEntity
        {
            Id = "98fee139-00a1-4da6-ad61-92998e41264a",
            UserName = "technicaltest@test.com",
            NormalizedUserName = "technicaltest@test.com",
            Email = "technicaltest@test.com",
            NormalizedEmail = "technicaltest@test.com",
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "P@ssw0rd789"),
            ConcurrencyStamp = "e48a48ed-9b58-495f-93e3-6a215f34cac7",
            SecurityStamp = "ac45eba8-b6e8-4c9a-a4a2-cb2f16463c81",
        };

        builder.Entity<UserEntity>().HasData(adminUser);

        #endregion

        // Assign roles to users
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = adminRole.Id,
                UserId = adminUser.Id
            }
        );

        #region CountryEntity

        builder.ConfigureCreatedAudit<CountryEntity>();
        builder.ConfigureUpdatedAudit<CountryEntity>();

        builder.Entity<CountryEntity>()
            .Property(p => p.Code)
            .HasMaxLength(3)
            .IsRequired();

        builder.Entity<CountryEntity>()
            .Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Entity<CountryEntity>().HasData(
            new CountryEntity { Id = 1, Code = "USA", Name = "United States" },
            new CountryEntity { Id = 2, Code = "CAN", Name = "Canada" },
            new CountryEntity { Id = 3, Code = "GBR", Name = "United Kingdom" },
            new CountryEntity { Id = 4, Code = "AUS", Name = "Australia" },
            new CountryEntity { Id = 5, Code = "IND", Name = "India" },
            new CountryEntity { Id = 6, Code = "DEU", Name = "Germany" },
            new CountryEntity { Id = 7, Code = "FRA", Name = "France" },
            new CountryEntity { Id = 8, Code = "ITA", Name = "Italy" },
            new CountryEntity { Id = 9, Code = "ESP", Name = "Spain" },
            new CountryEntity { Id = 10, Code = "JPN", Name = "Japan" },
            new CountryEntity { Id = 11, Code = "CHN", Name = "China" },
            new CountryEntity { Id = 12, Code = "BRA", Name = "Brazil" },
            new CountryEntity { Id = 13, Code = "MEX", Name = "Mexico" },
            new CountryEntity { Id = 14, Code = "RUS", Name = "Russia" },
            new CountryEntity { Id = 15, Code = "ZAF", Name = "South Africa" },
            new CountryEntity { Id = 16, Code = "KOR", Name = "South Korea" },
            new CountryEntity { Id = 17, Code = "ARG", Name = "Argentina" },
            new CountryEntity { Id = 18, Code = "SAU", Name = "Saudi Arabia" },
            new CountryEntity { Id = 19, Code = "TUR", Name = "Turkey" },
            new CountryEntity { Id = 20, Code = "NLD", Name = "Netherlands" },
            new CountryEntity { Id = 21, Code = "SWE", Name = "Sweden" },
            new CountryEntity { Id = 22, Code = "NOR", Name = "Norway" },
            new CountryEntity { Id = 23, Code = "DNK", Name = "Denmark" },
            new CountryEntity { Id = 24, Code = "FIN", Name = "Finland" },
            new CountryEntity { Id = 25, Code = "CHE", Name = "Switzerland" },
            new CountryEntity { Id = 26, Code = "AUT", Name = "Austria" },
            new CountryEntity { Id = 27, Code = "BEL", Name = "Belgium" },
            new CountryEntity { Id = 28, Code = "PRT", Name = "Portugal" },
            new CountryEntity { Id = 29, Code = "POL", Name = "Poland" },
            new CountryEntity { Id = 30, Code = "GRC", Name = "Greece" },
            new CountryEntity { Id = 31, Code = "IRL", Name = "Ireland" },
            new CountryEntity { Id = 32, Code = "NZL", Name = "New Zealand" },
            new CountryEntity { Id = 33, Code = "SGP", Name = "Singapore" },
            new CountryEntity { Id = 34, Code = "THA", Name = "Thailand" },
            new CountryEntity { Id = 35, Code = "IDN", Name = "Indonesia" },
            new CountryEntity { Id = 36, Code = "MYS", Name = "Malaysia" },
            new CountryEntity { Id = 37, Code = "PHL", Name = "Philippines" },
            new CountryEntity { Id = 38, Code = "VNM", Name = "Vietnam" },
            new CountryEntity { Id = 39, Code = "EGY", Name = "Egypt" },
            new CountryEntity { Id = 40, Code = "NGA", Name = "Nigeria" }
        );

        #endregion

        #region ItemCategoryEntity

        builder.ConfigureCreatedAudit<ItemCategoryEntity>();
        builder.ConfigureUpdatedAudit<ItemCategoryEntity>();

        builder.Entity<ItemCategoryEntity>()
            .Property(p => p.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Entity<ItemCategoryEntity>()
            .Property(p => p.Description)
            .HasMaxLength(100);

        #endregion

        #region ItemEntity

        builder.ConfigureCreatedAudit<ItemEntity>();
        builder.ConfigureUpdatedAudit<ItemEntity>();

        #endregion

        #region UserNotificationEntity

        builder.Entity<UserNotificationEntity>()
            .HasOne(k => k.User)
            .WithMany()
            .HasForeignKey(k => k.UserId);

        builder.Entity<UserNotificationEntity>()
            .Property(p => p.Subject)
            .HasMaxLength(100)
            .IsRequired();

        builder.Entity<UserNotificationEntity>()
            .Property(p => p.Body)
            .HasMaxLength(5000)
            .IsRequired();

        builder.Entity<UserNotificationEntity>()
            .Property(p => p.Read)
            .IsRequired();

        #endregion
    }
}