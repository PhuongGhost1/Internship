using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Payment.PaymentCourse;

namespace BE.Dto.Payment
{
    public class PaymentDto
    {
        public List<PaymentCourseDto> PaymentCourses {get; set;} = new List<PaymentCourseDto>();
        public float? Total { get; set; }
    }
}