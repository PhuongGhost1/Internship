using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Category;
using BE.Dto.Chapter;

namespace BE.Dto.Course
{
    public class CourseProcessingDto
    {
        public string Id { get; set; } = null!;

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public float? Price { get; set; }

        public string? UserId { get; set; }

        public int? Status { get; set; }

        public bool? IsVisible { get; set; }

        public float? Rating { get; set; }

        public string? WhatLearn { get; set; }

        public int Percent { get; set; }

        public string? ImageBackground { get; set; } = string.Empty;

    }
}