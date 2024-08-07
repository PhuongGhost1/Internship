using BE.Models;
using BE.Repository.Interface;
using Google;
using Microsoft.EntityFrameworkCore;

namespace BE.Repository.Implementations
{
    public class CartRepository : ICartRepository
    {
        private readonly CourseOnlContext _context;

        public CartRepository(CourseOnlContext context)
        {
            _context = context;
        }

        public async Task<Cart> GetCartByIdAsync(string cartId)
        {
            return await _context.Carts.Include(c => c.CartCourses).FirstOrDefaultAsync(c => c.Id == cartId);
        }

        public async Task AddToCartAsync(CartCourse cartCourse)
        {
            await _context.CartCourses.AddAsync(cartCourse);
        }

        public async Task RemoveFromCartAsync(string cartId, string courseId)
        {
            var cartCourse = await _context.CartCourses
                .FirstOrDefaultAsync(cc => cc.CartId == cartId && cc.CourseId == courseId);

            if (cartCourse != null)
            {
                _context.CartCourses.Remove(cartCourse);
            }
        }

        public async Task<Cart?> GetCartByUserIdAsync(string userId)
        {
            return await _context.Carts.Include(c => c.CartCourses)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Cart?> GetCartById(string cartId)
        {
            return await _context.Carts.FirstOrDefaultAsync(c => c.Id == cartId);
        }

        public async Task<CartCourse?> GetCartCourseById(string cartCourseId)
        {
            return await _context.CartCourses.FirstOrDefaultAsync(cc => cc.Id == cartCourseId);
        }

        public async Task UpdateCart(Cart cart)
        {
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();
        }

        public async Task<string?> GetCartIdByUserId(string userId)
        {
            return await _context.Carts.Where(cart => cart.UserId == userId).Select(cart => cart.Id).FirstOrDefaultAsync();
        }

        public async Task<List<string>> GetCartCourseByCartId(string cartId)
        {
            return await _context.CartCourses.Where(cc => cc.CartId == cartId).Select(cc => cc.Id).ToListAsync();
        }

        public async Task<int?> CountNumberInCart(string userId)
        {
            var user = await _context.Users
                .Include(u => u.Carts)
                    .ThenInclude(cart => cart.CartCourses)
                        .ThenInclude(cc => cc.Course)
                            .ThenInclude(course => course.Images)
                .Include(u => u.Carts)
                    .ThenInclude(cart => cart.CartCourses)
                        .ThenInclude(cc => cc.Course)
                            .ThenInclude(c => c.User)
                .Include(u => u.Carts)
                    .ThenInclude(cart => cart.CartCourses)
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return null;
            }

            var paidPaymentIds = await _context.Payments
                .Where(p => p.UserId == userId && p.Status == 1)
                .Select(p => p.Id)
                .ToListAsync();

            var paidCartCourseIds = await _context.PaymentCourses
                .Where(pc => paidPaymentIds.Contains(pc.PaymentId))
                .Select(pc => pc.CartcourseId)
                .ToListAsync();

            int totalCourses = 0;

            foreach (var cart in user.Carts)
            {
                foreach (var cc in cart.CartCourses)
                {
                    if (cc.Course != null && !(paidCartCourseIds.Contains(cc.Id)))
                    {
                        totalCourses++;
                    }
                }
            }

            return totalCourses;
        }
    }
}
