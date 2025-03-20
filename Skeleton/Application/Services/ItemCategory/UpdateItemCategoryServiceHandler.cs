using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Skeleton.Application.Common;
using Skeleton.Infrastructure.Data;

namespace Skeleton.Application.Services.ItemCategory;

public class UpdateItemCategoryServiceHandler : IServiceHandler<UpdateItemCategoryRequest>
{
    private readonly ApplicationDbContext _context;
    private readonly IServiceProvider _serviceProvider;

    public UpdateItemCategoryServiceHandler(ApplicationDbContext context, IServiceProvider serviceProvider)
    {
        _context = context;
        _serviceProvider = serviceProvider;
    }

    public Response Handle(UpdateItemCategoryRequest request)
    {
        var validator = _serviceProvider.GetService<IValidator<UpdateItemCategoryRequest>>();
        validator.ValidateAndThrow(request);

        var data = _context.ItemCategories
            .FirstOrDefault(x => x.Id == request.Id) ?? throw new NullReferenceException("Item Category");

        data.Name = request.Name!;
        data.Description = request.Description;

        _context.SaveChanges();

        return new Response().Ok();
    }
}