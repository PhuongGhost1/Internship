using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Dto.Course
{
    public class UpdateCourseDto
    {
        public string? CourseId {get; set;}
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public string? WhatLearn { get; set; }
    }
}