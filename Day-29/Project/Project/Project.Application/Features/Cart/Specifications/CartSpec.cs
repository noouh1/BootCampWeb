using Ardalis.Specification;

namespace Project.Application.Features.Cart.Specifications;

public class CartSpec : Specification<Domain.Models.Cart.Cart>
{
    public CartSpec( int pageSize, int pageNumber)
    {
        Query.Skip(pageSize * (pageNumber - 1));
        Query.Take(pageSize);
    }
}