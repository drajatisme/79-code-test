using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Skeleton.Application.Common;
using Skeleton.Domain.Entities;
using Skeleton.Infrastructure.Data;

namespace Skeleton.Application.Services.Item;

public class CreateItemServiceHandler : IServiceHandler<CreateItemRequest>
{
    private readonly ApplicationDbContext _context;
    private readonly IServiceProvider _serviceProvider;

    public CreateItemServiceHandler(ApplicationDbContext context, IServiceProvider serviceProvider)
    {
        _context = context;
        _serviceProvider = serviceProvider;
    }

    public Response Handle(CreateItemRequest request)
    {
        var validator = _serviceProvider.GetService<IValidator<CreateItemRequest>>();
        validator.ValidateAndThrow(request);

        var categoryExist = _context.ItemCategories.Any(a => a.Id == request.Category!.Value);
        if (!categoryExist)
            throw new NullReferenceException("Category");

        _context.Items.Add(new ItemEntity
        {
            Name = request.Name!,
            Description = request.Description,
            ItemCategoryId = request.Category!.Value
        });

        _context.SaveChanges();

        return new Response().Ok();
    }
}