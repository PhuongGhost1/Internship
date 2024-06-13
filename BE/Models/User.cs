using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Description { get; set; }

    public string? Phone { get; set; }

    public DateTime? CreateAt { get; set; }

    public bool? IsVisible { get; set; }

    public virtual ICollection<Affiliate> Affiliates { get; set; } = new List<Affiliate>();

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<EnrollCourse> EnrollCourses { get; set; } = new List<EnrollCourse>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Follow> FollowFolloweds { get; set; } = new List<Follow>();

    public virtual ICollection<Follow> FollowFollowers { get; set; } = new List<Follow>();

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual ICollection<Notification> NotificationReceiveds { get; set; } = new List<Notification>();

    public virtual ICollection<Notification> NotificationSenders { get; set; } = new List<Notification>();

    public virtual ICollection<Processing> Processings { get; set; } = new List<Processing>();

    public virtual ICollection<Report> ReportReportedUsers { get; set; } = new List<Report>();

    public virtual ICollection<Report> ReportReporters { get; set; } = new List<Report>();

    public virtual ICollection<RoleUser> RoleUsers { get; set; } = new List<RoleUser>();

    public virtual ICollection<SaveCourse> SaveCourses { get; set; } = new List<SaveCourse>();

    public virtual ICollection<Submission> Submissions { get; set; } = new List<Submission>();

    public virtual ICollection<UserCertification> UserCertifications { get; set; } = new List<UserCertification>();
}
