using BE.Dto.Cart;
using BE.Models;
using BE.Repository.Interface;
using BE.Services.Interfaces;
using Org.BouncyCastle.Crypto;

namespace BE.Services.Implementations
{
   /* public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public CartService(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<CartDTO> GetCartAsync(string cartId)
        {
            var cart = await _cartRepository.GetCartByIdAsync(cartId);
            return _mapper.Map<CartDTO>(cart);
        }

        public async Task AddToCartAsync(AddToCartDTO addToCartDto)
        {
            var cartCourse = new CartCourse
            {
                CartId = addToCartDto.CartId,
                CourseId = addToCartDto.CourseId
            };
            await _cartRepository.AddToCartAsync(cartCourse);
            await _cartRepository.SaveAsync();
        }

        public async Task RemoveFromCartAsync(string cartId, string courseId)
        {
            await _cartRepository.RemoveFromCartAsync(cartId, courseId);
            await _cartRepository.SaveAsync();
        }

        public async Task<CartDTO> ViewCartAsync(string userId)
        {
            var cart = await _cartRepository.GetCartByUserIdAsync(userId);
            return _mapper.Map<CartDTO>(cart);
        }
    }*/
}
