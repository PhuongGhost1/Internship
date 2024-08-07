using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using BE.Controllers;
using BE.Models;
using BE.Services.Interfaces;
using Xunit;
using FluentAssertions;
using BE.Dto.Course;
using BE.Dto.Message;

namespace WebAPI.Tests.Controllers
{
    public class CourseControllerTests
    {
        private readonly CourseWebController _controller;
        private readonly Mock<ICourseService> _courseService;
        public CourseControllerTests()
        {
            _courseService = new Mock<ICourseService>();
            _controller = new CourseWebController(_courseService.Object);
        }

        [Fact]
        public async Task AddToCart_ReturnsOkResult_WhenItemAddedSuccessfully()
        {
            var courseDto = new CourseUserDto{
                CourseId = "course_078b44d29b",
                UserId = "user_00ebd16723"
            };

            var message = new MessageDto{
                Message = "Add Course to cart Success",
                Status = 1
            };

            // Arrange
            _courseService.Setup(x => x.AddCourseToCart(courseDto)).ReturnsAsync(message);

            // Act
            var result = await _controller.AddCourseToCart(courseDto);

            // Assert
            result.Should().BeEquivalentTo<MessageDto>(message);
        }

        [Fact]
        public async Task RemoveFromCart_ReturnsOkResult_WhenItemRemovedSuccessfully()
        {
            var cartCourseId = "cartcourse_1d92d8c916";

            var message = new MessageDto{
                Message = "Remove Course from cart Success",
                Status = 1
            };
            // Arrange
            _courseService.Setup(x => x.DeleteItemFromCart(cartCourseId)).ReturnsAsync(message);

            // Act
            var result = await _controller.DeleteItemFromCart(cartCourseId);

            // Assert
            result.Should().BeEquivalentTo<MessageDto>(message);
        }

        [Fact]
        public async Task GetCart_ReturnsCart_WhenCartExists()
        {
            var courseId = "course_078b44d29b";
            var cartId = "cart_1d92d8c916";

            // Arrange
            _courseService.Setup(x => x.IsCourseInCartAsync(cartId, courseId)).ReturnsAsync(true);

            // Act
            var result = await _controller.IsCourseInCart(cartId, courseId);

            // Assert
            result.Should().Be(true);
        }
    }
}
