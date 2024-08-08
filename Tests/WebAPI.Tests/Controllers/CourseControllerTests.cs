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
using BE.Dto.Cart;
using BE.Dto.User;
using BE.Controllers;

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
        public async Task ViewCart_ReturnsListCart_WhenCartExists()
        {
            var cartId = "cart_1d92d8c916";
            var userId = "user_00ebd16723";

            var user = new UserCartDto
            {
                Id = userId,
                Username = "user1",
                Email = "",
                Carts = new List<CartDTO>
                {
                    new CartDTO
                    {
                        Id = cartId,
                        UserId = userId,
                        DateCreated = DateTime.Now,
                        Total = 1000.00f,
                        Status = 1,
                        CartCourses = new List<CartCourseDTO>
                        {
                            new CartCourseDTO
                            {
                                CartCourseId = "cartcourse_1d92d8c916",
                                Cart = new CartDTO
                                {
                                    Id = cartId,
                                    UserId = userId,
                                    DateCreated = DateTime.Now,
                                    Total = 1000.0f,
                                    Status = 1
                                },
                                Course = new CourseForCartDto
                                {
                                    Id = "course_078b44d29b",
                                    Name = "Introduction to Programming",
                                    Description = "This course is an introduction to programming",
                                    Price = 1000,
                                    imgUrl = "https://www.example.com/image.jpg"
                                }
                            }
                        }
                    }
                }
            };

            // Arrange
            _courseService.Setup(x => x.GetListCartCourse(userId)).ReturnsAsync(user);

            // Act
            var result = await _controller.ViewCart(userId);

            // Assert
            result.Should().BeEquivalentTo(user);
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
            var result = await _controller.IsCourseInCart(cartId, courseId) as OkObjectResult;

            // Assert
            result.Should().NotBeNull();
            result.Value.Should().Be(true);
        }

        [Fact]
        public async Task GetQuiz_ReturnsQuiz_WhenQuizExists()
        {
            var chapterId = "course_078b44d29b";
            var quizId = "quiz_1d92d8c916";

            var quiz = new Quiz{
                Id = quizId,
                ChapterId = chapterId,
                Questions = new List<Question>{
                    new Question{
                        Id = "question_1d92d8c916",
                        Answers = new List<Answer>{
                            new Answer{
                                Id = "option_1d92d8c916",
                                Text = "Abuja",
                                IsCorrect = true
                            },
                            new Answer{
                                Id = "option_1d92d8c917",
                                Text = "Lagos",
                                IsCorrect = false
                            },
                            new Answer{
                                Id = "option_1d92d8c918",
                                Text = "Kano",
                                IsCorrect = false
                            },
                            new Answer{
                                Id = "option_1d92d8c919",
                                Text = "Ibadan",
                                IsCorrect = false
                            }
                        }
                    }
                }
            };

            // Arrange
            _courseService.Setup(x => x.GetQuizByHashCode(quizId)).ReturnsAsync(quiz);

            // Act
            var result = await _controller.GetQuizByHashCode(quizId);

            // Assert
            result.Should().BeEquivalentTo<Quiz>(quiz);
        }

        [Fact]
        public async Task GetLecture_ReturnsLecture_WhenQuizExists()
        {
            var chapterId = "course_078b44d29b";
            var lectureId = "lecture_1d92d8c916";

            var lecture = new Lecture{
                Id = lectureId,
                ChapterId = chapterId,
                Name = "Introduction to Programming",
                VideoUrl = "https://www.youtube.com/watch?v=video_id"
            };

            // Arrange
            _courseService.Setup(x => x.GetLectureByHashCode(lectureId)).ReturnsAsync(lecture);

            // Act
            var result = await _controller.GetLectureByHashCode(lectureId);

            // Assert
            result.Should().BeEquivalentTo<Lecture>(lecture);
        }
    }
}
