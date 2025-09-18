using Ardalis.Specification;

namespace Project.Application.Features.CartItem.Specifications;

public class CartItemSpec : Specification<Domain.Models.CartItem.CartItem>
{
    public CartItemSpec( int pageSize, int pageNumber)
    {
        Query.Skip(pageSize * (pageNumber - 1));
        Query.Take(pageSize);
    }
}