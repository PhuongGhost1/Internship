using BE.Dto.Cart;

namespace BE.Services.Interfaces
{
    public interface ICartService
    {
        Task<CartDTO> GetCartAsync(string cartId);
        Task AddToCartAsync(AddToCartDTO addToCartDto);
        Task RemoveFromCartAsync(string cartId, string courseId);
        Task<CartDTO> ViewCartAsync(string userId);
    }
}
