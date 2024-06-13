using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace BE.Models;

public partial class CourseOnlContext : DbContext
{
    public CourseOnlContext()
    {
    }

    public CourseOnlContext(DbContextOptions<CourseOnlContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Affiliate> Affiliates { get; set; }

    public virtual DbSet<Answear> Answears { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartCourse> CartCourses { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CategoryCourse> CategoryCourses { get; set; }

    public virtual DbSet<Certification> Certifications { get; set; }

    public virtual DbSet<Chapter> Chapters { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<EnrollCourse> EnrollCourses { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Follow> Follows { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Lecture> Lectures { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Permisson> Permissons { get; set; }

    public virtual DbSet<Processing> Processings { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Quiz> Quizzes { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Resource> Resources { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RoleUser> RoleUsers { get; set; }

    public virtual DbSet<SaveCourse> SaveCourses { get; set; }

    public virtual DbSet<Submission> Submissions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserCertification> UserCertifications { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=courseonline.cziokaqumdw8.ap-southeast-1.rds.amazonaws.com;port=3306;database=CourseOnl;user=admin;password=12345678", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.36-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Affiliate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Affiliate");

            entity.HasIndex(e => e.CourseId, "courseId");

            entity.HasIndex(e => new { e.CreateBy, e.CourseId }, "unique_user_course").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommissionPercent).HasColumnName("commissionPercent");
            entity.Property(e => e.CourseId).HasColumnName("courseId");
            entity.Property(e => e.CreateAt).HasColumnName("createAt");
            entity.Property(e => e.CreateBy).HasColumnName("createBy");
            entity.Property(e => e.TotalCommission).HasColumnName("totalCommission");

            entity.HasOne(d => d.Course).WithMany(p => p.Affiliates)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("Affiliate_ibfk_2");

            entity.HasOne(d => d.CreateByNavigation).WithMany(p => p.Affiliates)
                .HasForeignKey(d => d.CreateBy)
                .HasConstraintName("Affiliate_ibfk_1");
        });

        modelBuilder.Entity<Answear>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Answear");

            entity.HasIndex(e => e.QuestionId, "questionId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.QuestionId).HasColumnName("questionId");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Text)
                .HasMaxLength(200)
                .HasColumnName("text");

            entity.HasOne(d => d.Question).WithMany(p => p.Answears)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("Answear_ibfk_1");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Cart");

            entity.HasIndex(e => e.PaymentId, "paymentId").IsUnique();

            entity.HasIndex(e => e.UserId, "userId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("dateCreated");
            entity.Property(e => e.PaymentId).HasColumnName("paymentId");
            entity.Property(e => e.Total).HasColumnName("total");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Payment).WithOne(p => p.Cart)
                .HasForeignKey<Cart>(d => d.PaymentId)
                .HasConstraintName("Cart_ibfk_2");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("Cart_ibfk_1");
        });

        modelBuilder.Entity<CartCourse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("CartCourse");

            entity.HasIndex(e => e.AffiliateId, "affiliateId");

            entity.HasIndex(e => e.CartId, "cartId");

            entity.HasIndex(e => e.CourseId, "courseId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AffiliateId).HasColumnName("affiliateId");
            entity.Property(e => e.CartId).HasColumnName("cartId");
            entity.Property(e => e.CourseId).HasColumnName("courseId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Total).HasColumnName("total");

            entity.HasOne(d => d.Affiliate).WithMany(p => p.CartCourses)
                .HasForeignKey(d => d.AffiliateId)
                .HasConstraintName("CartCourse_ibfk_3");

            entity.HasOne(d => d.Cart).WithMany(p => p.CartCourses)
                .HasForeignKey(d => d.CartId)
                .HasConstraintName("CartCourse_ibfk_1");

            entity.HasOne(d => d.Course).WithMany(p => p.CartCourses)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("CartCourse_ibfk_2");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<CategoryCourse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("CategoryCourse");

            entity.HasIndex(e => e.CategoryId, "categoryId");

            entity.HasIndex(e => e.CourseId, "courseId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.CourseId).HasColumnName("courseId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");

            entity.HasOne(d => d.Category).WithMany(p => p.CategoryCourses)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("CategoryCourse_ibfk_2");

            entity.HasOne(d => d.Course).WithMany(p => p.CategoryCourses)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("CategoryCourse_ibfk_1");
        });

        modelBuilder.Entity<Certification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Certification");

            entity.HasIndex(e => e.CourseId, "courseId").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CourseId).HasColumnName("courseId");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.Course).WithOne(p => p.Certification)
                .HasForeignKey<Certification>(d => d.CourseId)
                .HasConstraintName("Certification_ibfk_1");
        });

        modelBuilder.Entity<Chapter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Chapter");

            entity.HasIndex(e => e.CourseId, "courseId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CourseId).HasColumnName("courseId");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("createAt");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .HasColumnName("description");
            entity.Property(e => e.Index).HasColumnName("index");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Course).WithMany(p => p.Chapters)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("Chapter_ibfk_1");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Comment");

            entity.HasIndex(e => e.CourseId, "courseId");

            entity.HasIndex(e => e.UserId, "userId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment1)
                .HasMaxLength(300)
                .HasColumnName("comment");
            entity.Property(e => e.CourseId).HasColumnName("courseId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.IsVisible).HasColumnName("isVisible");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Course).WithMany(p => p.Comments)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("Comment_ibfk_1");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("Comment_ibfk_2");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Course");

            entity.HasIndex(e => e.OwnerId, "ownerId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("createAt");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .HasColumnName("description");
            entity.Property(e => e.IsVisible).HasColumnName("isVisible");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.OwnerId).HasColumnName("ownerId");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Owner).WithMany(p => p.Courses)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("Course_ibfk_1");
        });

        modelBuilder.Entity<EnrollCourse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("EnrollCourse");

            entity.HasIndex(e => e.CourseId, "courseId");

            entity.HasIndex(e => e.UserId, "userId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CourseId).HasColumnName("courseId");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Course).WithMany(p => p.EnrollCourses)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("EnrollCourse_ibfk_2");

            entity.HasOne(d => d.User).WithMany(p => p.EnrollCourses)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("EnrollCourse_ibfk_1");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Feedback");

            entity.HasIndex(e => e.UserId, "userId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("Feedback_ibfk_1");
        });

        modelBuilder.Entity<Follow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Follow");

            entity.HasIndex(e => e.FollowedId, "followedId");

            entity.HasIndex(e => e.FollowerId, "followerId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FollowedId).HasColumnName("followedId");
            entity.Property(e => e.FollowerId).HasColumnName("followerId");
            entity.Property(e => e.Time)
                .HasColumnType("datetime")
                .HasColumnName("time");

            entity.HasOne(d => d.Followed).WithMany(p => p.FollowFolloweds)
                .HasForeignKey(d => d.FollowedId)
                .HasConstraintName("Follow_ibfk_2");

            entity.HasOne(d => d.Follower).WithMany(p => p.FollowFollowers)
                .HasForeignKey(d => d.FollowerId)
                .HasConstraintName("Follow_ibfk_1");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Image");

            entity.HasIndex(e => e.CourseId, "courseId");

            entity.HasIndex(e => e.FeedbackId, "feedbackId");

            entity.HasIndex(e => e.LectureId, "lectureId");

            entity.HasIndex(e => e.UserId, "userId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Base64Code)
                .HasColumnType("mediumtext")
                .HasColumnName("base64Code");
            entity.Property(e => e.CourseId).HasColumnName("courseId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.FeedbackId).HasColumnName("feedbackId");
            entity.Property(e => e.LectureId).HasColumnName("lectureId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Course).WithMany(p => p.Images)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("Image_ibfk_2");

            entity.HasOne(d => d.Feedback).WithMany(p => p.Images)
                .HasForeignKey(d => d.FeedbackId)
                .HasConstraintName("Image_ibfk_4");

            entity.HasOne(d => d.Lecture).WithMany(p => p.Images)
                .HasForeignKey(d => d.LectureId)
                .HasConstraintName("Image_ibfk_3");

            entity.HasOne(d => d.User).WithMany(p => p.Images)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("Image_ibfk_1");
        });

        modelBuilder.Entity<Lecture>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Lecture");

            entity.HasIndex(e => e.ChapterId, "chapterId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChapterId).HasColumnName("chapterId");
            entity.Property(e => e.CreatAt)
                .HasColumnType("datetime")
                .HasColumnName("creatAt");
            entity.Property(e => e.Index).HasColumnName("index");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.TimeVideo)
                .HasColumnType("time")
                .HasColumnName("timeVideo");
            entity.Property(e => e.VideoUrl)
                .HasMaxLength(100)
                .HasColumnName("videoUrl");

            entity.HasOne(d => d.Chapter).WithMany(p => p.Lectures)
                .HasForeignKey(d => d.ChapterId)
                .HasConstraintName("Lecture_ibfk_1");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Notification");

            entity.HasIndex(e => e.ReceivedId, "receivedId");

            entity.HasIndex(e => e.SenderId, "senderId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateUp)
                .HasColumnType("datetime")
                .HasColumnName("dateUp");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.IsRead).HasColumnName("isRead");
            entity.Property(e => e.ReceivedId).HasColumnName("receivedId");
            entity.Property(e => e.SenderId).HasColumnName("senderId");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");

            entity.HasOne(d => d.Received).WithMany(p => p.NotificationReceiveds)
                .HasForeignKey(d => d.ReceivedId)
                .HasConstraintName("Notification_ibfk_2");

            entity.HasOne(d => d.Sender).WithMany(p => p.NotificationSenders)
                .HasForeignKey(d => d.SenderId)
                .HasConstraintName("Notification_ibfk_1");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Payment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.PaymendCode)
                .HasMaxLength(50)
                .HasColumnName("paymendCode");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .HasColumnName("paymentMethod");
            entity.Property(e => e.Total).HasColumnName("total");
        });

        modelBuilder.Entity<Permisson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Permisson");

            entity.HasIndex(e => e.ResourcesId, "resourcesId");

            entity.HasIndex(e => e.RoleId, "roleId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Create).HasColumnName("create");
            entity.Property(e => e.Delete).HasColumnName("delete");
            entity.Property(e => e.LastUpdate)
                .HasColumnType("datetime")
                .HasColumnName("lastUpdate");
            entity.Property(e => e.ResourcesId).HasColumnName("resourcesId");
            entity.Property(e => e.RoleId).HasColumnName("roleId");
            entity.Property(e => e.Update).HasColumnName("update");
            entity.Property(e => e.View).HasColumnName("view");

            entity.HasOne(d => d.Resources).WithMany(p => p.Permissons)
                .HasForeignKey(d => d.ResourcesId)
                .HasConstraintName("Permisson_ibfk_2");

            entity.HasOne(d => d.Role).WithMany(p => p.Permissons)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("Permisson_ibfk_1");
        });

        modelBuilder.Entity<Processing>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Processing");

            entity.HasIndex(e => e.LectureId, "lectureId");

            entity.HasIndex(e => e.QuizId, "quizId");

            entity.HasIndex(e => e.UserId, "userId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("createAt");
            entity.Property(e => e.LectureId).HasColumnName("lectureId");
            entity.Property(e => e.QuizId).HasColumnName("quizId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Lecture).WithMany(p => p.Processings)
                .HasForeignKey(d => d.LectureId)
                .HasConstraintName("Processing_ibfk_2");

            entity.HasOne(d => d.Quiz).WithMany(p => p.Processings)
                .HasForeignKey(d => d.QuizId)
                .HasConstraintName("Processing_ibfk_3");

            entity.HasOne(d => d.User).WithMany(p => p.Processings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("Processing_ibfk_1");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Question");

            entity.HasIndex(e => e.QuizId, "quizId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("createAt");
            entity.Property(e => e.Mark).HasColumnName("mark");
            entity.Property(e => e.QuizId).HasColumnName("quizId");
            entity.Property(e => e.Text)
                .HasMaxLength(200)
                .HasColumnName("text");
            entity.Property(e => e.Type).HasColumnName("type");

            entity.HasOne(d => d.Quiz).WithMany(p => p.Questions)
                .HasForeignKey(d => d.QuizId)
                .HasConstraintName("Question_ibfk_1");
        });

        modelBuilder.Entity<Quiz>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Quiz");

            entity.HasIndex(e => e.ChapterId, "chapterId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChapterId).HasColumnName("chapterId");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("createAt");
            entity.Property(e => e.Index).HasColumnName("index");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.NumberOfQuestions).HasColumnName("numberOfQuestions");
            entity.Property(e => e.PassPercent).HasColumnName("passPercent");
            entity.Property(e => e.TotalMark).HasColumnName("totalMark");

            entity.HasOne(d => d.Chapter).WithMany(p => p.Quizzes)
                .HasForeignKey(d => d.ChapterId)
                .HasConstraintName("Quiz_ibfk_1");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Report");

            entity.HasIndex(e => e.CommentId, "commentId");

            entity.HasIndex(e => e.CourseId, "courseId");

            entity.HasIndex(e => e.ReportedUserId, "reportedUserId");

            entity.HasIndex(e => e.ReporterId, "reporterId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommentId).HasColumnName("commentId");
            entity.Property(e => e.CourseId).HasColumnName("courseId");
            entity.Property(e => e.Message)
                .HasMaxLength(200)
                .HasColumnName("message");
            entity.Property(e => e.ReportedUserId).HasColumnName("reportedUserId");
            entity.Property(e => e.ReporterId).HasColumnName("reporterId");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");

            entity.HasOne(d => d.Comment).WithMany(p => p.Reports)
                .HasForeignKey(d => d.CommentId)
                .HasConstraintName("Report_ibfk_2");

            entity.HasOne(d => d.Course).WithMany(p => p.Reports)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("Report_ibfk_3");

            entity.HasOne(d => d.ReportedUser).WithMany(p => p.ReportReportedUsers)
                .HasForeignKey(d => d.ReportedUserId)
                .HasConstraintName("Report_ibfk_1");

            entity.HasOne(d => d.Reporter).WithMany(p => p.ReportReporters)
                .HasForeignKey(d => d.ReporterId)
                .HasConstraintName("Report_ibfk_4");
        });

        modelBuilder.Entity<Resource>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Role");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
        });

        modelBuilder.Entity<RoleUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("RoleUser");

            entity.HasIndex(e => e.RoleId, "roleId");

            entity.HasIndex(e => e.UserId, "userId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RoleId).HasColumnName("roleId");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Role).WithMany(p => p.RoleUsers)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("RoleUser_ibfk_1");

            entity.HasOne(d => d.User).WithMany(p => p.RoleUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("RoleUser_ibfk_2");
        });

        modelBuilder.Entity<SaveCourse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("SaveCourse");

            entity.HasIndex(e => e.CourseId, "courseId");

            entity.HasIndex(e => e.UserId, "userId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CourseId).HasColumnName("courseId");
            entity.Property(e => e.Time)
                .HasColumnType("datetime")
                .HasColumnName("time");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Course).WithMany(p => p.SaveCourses)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("SaveCourse_ibfk_2");

            entity.HasOne(d => d.User).WithMany(p => p.SaveCourses)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("SaveCourse_ibfk_1");
        });

        modelBuilder.Entity<Submission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Submission");

            entity.HasIndex(e => e.QuizzId, "quizzId");

            entity.HasIndex(e => e.UserId, "userId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Grade).HasColumnName("grade");
            entity.Property(e => e.QuizzId).HasColumnName("quizzId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Quizz).WithMany(p => p.Submissions)
                .HasForeignKey(d => d.QuizzId)
                .HasConstraintName("Submission_ibfk_1");

            entity.HasOne(d => d.User).WithMany(p => p.Submissions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("Submission_ibfk_2");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("createAt");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .HasColumnName("email");
            entity.Property(e => e.IsVisible).HasColumnName("isVisible");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .HasColumnName("username");
        });

        modelBuilder.Entity<UserCertification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("UserCertification");

            entity.HasIndex(e => e.CertificationId, "certificationId");

            entity.HasIndex(e => e.UserId, "userId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CertificationId).HasColumnName("certificationId");
            entity.Property(e => e.DatePass)
                .HasColumnType("datetime")
                .HasColumnName("datePass");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Certification).WithMany(p => p.UserCertifications)
                .HasForeignKey(d => d.CertificationId)
                .HasConstraintName("UserCertification_ibfk_1");

            entity.HasOne(d => d.User).WithMany(p => p.UserCertifications)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("UserCertification_ibfk_2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
