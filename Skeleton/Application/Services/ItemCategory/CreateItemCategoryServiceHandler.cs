using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Skeleton.Application.Common;
using Skeleton.Domain.Entities;
using Skeleton.Infrastructure.Data;

namespace Skeleton.Application.Services.ItemCategory;

public class CreateItemCategoryServiceHandler : IServiceHandler<CreateItemCategoryRequest>
{
    private readonly ApplicationDbContext _context;
    private readonly IServiceProvider _serviceProvider;

    public CreateItemCategoryServiceHandler(ApplicationDbContext context, IServiceProvider serviceProvider)
    {
        _context = context;
        _serviceProvider = serviceProvider;
    }

    public Response Handle(CreateItemCategoryRequest request)
    {
        var validator = _serviceProvider.GetService<IValidator<CreateItemCategoryRequest>>();
        validator.ValidateAndThrow(request);

        _context.ItemCategories.Add(new ItemCategoryEntity
        {
            Name = request.Name!,
            Description = request.Description
        });

        _context.SaveChanges();

        return new Response().Ok();
    }
}