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
        Task<Cart?> GetCartById(string cartId);
        Task<CartCourse?> GetCartCourseById(string cartCourseId);
        Task UpdateCart(Cart cart);
        Task<string?> GetCartIdByUserId(string userId);
        Task<List<string>> GetCartCourseByCartId(string cartId);
        Task<int?> CountNumberInCart(string userId);
    }
}
