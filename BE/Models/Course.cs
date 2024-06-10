using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Course
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime? CreateAt { get; set; }

    public float? Price { get; set; }

    public int? OwnerId { get; set; }

    public bool? Status { get; set; }

    public bool? IsVisible { get; set; }

    public float? Rating { get; set; }

    public virtual ICollection<Affiliate> Affiliates { get; set; } = new List<Affiliate>();

    public virtual ICollection<CartCourse> CartCourses { get; set; } = new List<CartCourse>();

    public virtual ICollection<CategoryCourse> CategoryCourses { get; set; } = new List<CategoryCourse>();

    public virtual Certification? Certification { get; set; }

    public virtual ICollection<Chapter> Chapters { get; set; } = new List<Chapter>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<EnrollCourse> EnrollCourses { get; set; } = new List<EnrollCourse>();

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual User? Owner { get; set; }

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual ICollection<SaveCourse> SaveCourses { get; set; } = new List<SaveCourse>();
}
