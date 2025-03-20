using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Skeleton.Application.Common;
using Skeleton.Infrastructure.Data;

namespace Skeleton.Application.Services.Item;

public class UpdateItemServiceHandler : IServiceHandler<UpdateItemRequest>
{
    private readonly ApplicationDbContext _context;
    private readonly IServiceProvider _serviceProvider;

    public UpdateItemServiceHandler(ApplicationDbContext context, IServiceProvider serviceProvider)
    {
        _context = context;
        _serviceProvider = serviceProvider;
    }

    public Response Handle(UpdateItemRequest request)
    {
        var validator = _serviceProvider.GetService<IValidator<UpdateItemRequest>>();
        validator.ValidateAndThrow(request);
        
        var categoryExist = _context.ItemCategories.Any(a => a.Id == request.Category!.Value);
        if (!categoryExist)
            throw new NullReferenceException("Category");

        var data = _context.Items
            .FirstOrDefault(x => x.Id == request.Id) ?? throw new NullReferenceException("Item");

        data.Name = request.Name!;
        data.Description = request.Description;
        data.ItemCategoryId = request.Category!.Value;

        _context.SaveChanges();

        return new Response().Ok();
    }
}