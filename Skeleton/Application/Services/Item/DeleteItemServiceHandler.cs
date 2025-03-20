using Skeleton.Application.Common;
using Skeleton.Infrastructure.Data;

namespace Skeleton.Application.Services.Item;

public class DeleteItemServiceHandler : IServiceHandler<DeleteItemRequest>
{
    private readonly ApplicationDbContext _context;

    public DeleteItemServiceHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public Response Handle(DeleteItemRequest request)
    {
        var data = _context.Items
            .FirstOrDefault(x => x.Id == request.Id) ?? throw new NullReferenceException("Item");

        _context.Items.Remove(data);

        _context.SaveChanges();
        return new Response().Ok();
    }
}