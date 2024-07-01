namespace BE.Dto.Course
{
    public class CreateCoursData
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public string? WhatLearn { get; set; }
        public IFormFile? Avatar { get; set; }
        public IFormFile? Background { get; set; }
        public string? Categories { get; set; }
        public string? OwnerUsername { get; set; }
    }
}