using Microsoft.EntityFrameworkCore;
using Skeleton.Domain.Entities;

namespace Skeleton.Infrastructure.Extensions;

public static class ModelBuilderExtension
{
    public static void ConfigureCreatedAudit<TEntity>(this ModelBuilder builder) where TEntity : class, ICreateAuditable
    {
        builder.Entity<TEntity>()
            .HasOne(k => k.CreatedUser)
            .WithMany()
            .HasForeignKey(k => k.CreatedBy);
    }

    public static void ConfigureUpdatedAudit<TEntity>(this ModelBuilder builder) where TEntity : class, IUpdateAuditable
    {
        builder.Entity<TEntity>()
            .HasOne(k => k.UpdatedUser)
            .WithMany()
            .HasForeignKey(k => k.UpdatedBy);
    }
}