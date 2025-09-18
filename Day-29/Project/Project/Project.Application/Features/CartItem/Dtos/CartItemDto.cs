namespace Project.Application.Features.CartItem.Dtos;

public record CartItemDto(Guid ProductId, int Quantity, decimal UnitPrice);