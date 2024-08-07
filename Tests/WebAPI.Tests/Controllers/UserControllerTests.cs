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
    public class UserControllerTests
    {
        private readonly UserWebController _controller;
        private readonly Mock<IUserService> _userService;
        public UserControllerTests()
        {
            _userService = new Mock<IUserService>();
            _controller = new UserWebController(_userService.Object);
        }

        [Fact]
        public async Task GetUserById_ReturnsUser_WhenUserExists()
        {
            // Arrange
            var actualUserId = "user_00ebd16723";
            var testUserId = "user_00ebd16723";
            var testUser = new User { Id = testUserId, Name = "Test User" };
            _userService.Setup(x => x.GetUSerById(testUserId)).ReturnsAsync(testUser);

            // Act
            var result = await _controller.GetUserById(actualUserId);

            // Assert
            result.Should().BeEquivalentTo(testUser);
        }

        [Fact]
        public async Task NumberInCart_ReturnsCorrectNumber()
        {
            // Arrange
            var userId = "user_00ebd16723";
            var expectedNumber = 2; 
            _userService.Setup(x => x.CountNumberInCartAsync(userId)).ReturnsAsync(2);

            // Act
            var result = await _controller.NumberInCart(userId);

            // Assert
            result.Should().Be(expectedNumber);
        }
    }
}
