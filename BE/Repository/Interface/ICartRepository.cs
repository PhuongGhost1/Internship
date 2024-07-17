using BE.Models;

namespace BE.Repository.Interface
{
    public interface ICartRepository
    {
        Task<Cart> GetCartByIdAsync(string cartId);
        Task AddToCartAsync(CartCourse cartCourse);
        Task RemoveFromCartAsync(string cartId, string courseId);
        Task<Cart> GetCartByUserIdAsync(string userId);
        Task SaveAsync();
    }
}
