using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.ImageD;

namespace BE.Dto.Course
{
    public class CourseManagementForAdminDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int? Status { get; set; }
        public DateTime? CreateAt {get; set;}
        public DateTime? UpdateAt {get; set;}
        public string? WhatLearn {get; set;}
        public List<ImageForAdminDto> Images = new List<ImageForAdminDto>();
    }
}