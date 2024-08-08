using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Course;
using BE.Dto.Payment.PaymentCourse;

namespace BE.Dto.Payment.CartCourse
{
    public class CartCourseDto
    {
        public CourseForAdminDto? CourseForAdminDto {get; set;}
        public PaymentCourseDto? PaymentCourses {get; set;}
    }
}