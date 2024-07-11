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

    public virtual DbSet<AffiliatePayment> AffiliatePayments { get; set; }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartCourse> CartCourses { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CategoryCourse> CategoryCourses { get; set; }

    public virtual DbSet<Certification> Certifications { get; set; }

    public virtual DbSet<Chapter> Chapters { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<DepositWithdrawal> DepositWithdrawals { get; set; }

    public virtual DbSet<EfmigrationsHistory> EfmigrationsHistories { get; set; }

    public virtual DbSet<EnrollCourse> EnrollCourses { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Follow> Follows { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Lecture> Lectures { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentCourse> PaymentCourses { get; set; }

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

    public virtual DbSet<Transaction> Transactions { get; set; }

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

            entity.HasIndex(e => e.CourseId, "course_id");

            entity.HasIndex(e => new { e.CreateBy, e.CourseId }, "unique_user_course").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .HasColumnName("id");
            entity.Property(e => e.CommissionPercent).HasColumnName("commission_percent");
            entity.Property(e => e.CourseId)
                .HasMaxLength(40)
                .HasColumnName("course_id");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(40)
                .HasColumnName("create_by");

            entity.HasOne(d => d.Course).WithMany(p => p.Affiliates)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("Affiliate_ibfk_2");

            entity.HasOne(d => d.CreateByNavigation).WithMany(p => p.Affiliates)
                .HasForeignKey(d => d.CreateBy)
                .HasConstraintName("Affiliate_ibfk_1");
        });

        modelBuilder.Entity<AffiliatePayment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("AffiliatePayment");

            entity.HasIndex(e => e.CartcourseId, "cartcourse_id");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .HasColumnName("id");
            entity.Property(e => e.CartcourseId)
                .HasMaxLength(40)
                .HasColumnName("cartcourse_id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.Total)
                .HasMaxLength(20)
                .HasColumnName("total");
            entity.Property(e => e.UserId)
                .HasMaxLength(40)
                .HasColumnName("user_id");

            entity.HasOne(d => d.Cartcourse).WithMany(p => p.AffiliatePayments)
                .HasForeignKey(d => d.CartcourseId)
                .HasConstraintName("AffiliatePayment_ibfk_1");

            entity.HasOne(d => d.User).WithMany(p => p.AffiliatePayments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("AffiliatePayment_ibfk_2");
        });

        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Answer");

            entity.HasIndex(e => e.QuestionId, "question_id");

            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.IsCorrect).HasColumnName("is_correct");
            entity.Property(e => e.QuestionId)
                .HasMaxLength(40)
                .HasColumnName("question_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Text)
                .HasMaxLength(300)
                .HasColumnName("text");

            entity.HasOne(d => d.Question).WithMany(p => p.Answers)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("Answer_ibfk_1");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Cart");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .HasColumnName("id");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Total).HasColumnName("total");
            entity.Property(e => e.UserId)
                .HasMaxLength(40)
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("Cart_ibfk_1");
        });

        modelBuilder.Entity<CartCourse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("CartCourse");

            entity.HasIndex(e => e.AffiliateId, "affiliate_id");

            entity.HasIndex(e => e.CartId, "cart_id");

            entity.HasIndex(e => e.CourseId, "course_id");

            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .HasColumnName("id");
            entity.Property(e => e.AffiliateId)
                .HasMaxLength(40)
                .HasColumnName("affiliate_id");
            entity.Property(e => e.CartId)
                .HasMaxLength(40)
                .HasColumnName("cart_id");
            entity.Property(e => e.CourseId)
                .HasMaxLength(40)
                .HasColumnName("course_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Status).HasColumnName("status");
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

            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<CategoryCourse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("CategoryCourse");

            entity.HasIndex(e => e.CategoryId, "category_id");

            entity.HasIndex(e => e.CourseId, "course_id");

            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .HasColumnName("id");
            entity.Property(e => e.CategoryId)
                .HasMaxLength(40)
                .HasColumnName("category_id");
            entity.Property(e => e.CourseId)
                .HasMaxLength(40)
                .HasColumnName("course_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");

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

            entity.HasIndex(e => e.CourseId, "course_id").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .HasColumnName("id");
            entity.Property(e => e.CourseId)
                .HasMaxLength(40)
                .HasColumnName("course_id");
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

            entity.HasIndex(e => e.CourseId, "course_id");

            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .HasColumnName("id");
            entity.Property(e => e.CourseId)
                .HasMaxLength(40)
                .HasColumnName("course_id");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("create_at");
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

            entity.HasIndex(e => e.CourseId, "course_id");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .HasColumnName("id");
            entity.Property(e => e.Comment1)
                .HasMaxLength(300)
                .HasColumnName("comment");
            entity.Property(e => e.CourseId)
                .HasMaxLength(40)
                .HasColumnName("course_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IsVisible).HasColumnName("is_visible");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.UserId)
                .HasMaxLength(40)
                .HasColumnName("user_id");

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

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.IsVisible).HasColumnName("is_visible");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UserId)
                .HasMaxLength(40)
                .HasColumnName("user_id");
            entity.Property(e => e.WhatLearn)
                .HasMaxLength(1000)
                .HasColumnName("what_learn");

            entity.HasOne(d => d.User).WithMany(p => p.Courses)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("Course_ibfk_1");
        });

        modelBuilder.Entity<DepositWithdrawal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("DepositWithdrawal");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.Total).HasColumnName("total");
            entity.Property(e => e.TransactionMethod)
                .HasMaxLength(50)
                .HasColumnName("transaction_method");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .HasColumnName("type");
            entity.Property(e => e.UserId)
                .HasMaxLength(40)
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.DepositWithdrawals)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("DepositWithdrawal_ibfk_1");
        });

        modelBuilder.Entity<EfmigrationsHistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__EFMigrationsHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<EnrollCourse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("EnrollCourse");

            entity.HasIndex(e => e.CourseId, "course_id");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .HasColumnName("id");
            entity.Property(e => e.CourseId)
                .HasMaxLength(40)
                .HasColumnName("course_id");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.UserId)
                .HasMaxLength(40)
                .HasColumnName("user_id");

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

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .HasColumnName("description");
            entity.Property(e => e.IsRead).HasColumnName("is_read");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
            entity.Property(e => e.UserId)
                .HasMaxLength(40)
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("Feedback_ibfk_1");
        });

        modelBuilder.Entity<Follow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Follow");

            entity.HasIndex(e => e.FollowedId, "followed_id");

            entity.HasIndex(e => e.FollowerId, "follower_id");

            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .HasColumnName("id");
            entity.Property(e => e.FollowedId)
                .HasMaxLength(40)
                .HasColumnName("followed_id");
            entity.Property(e => e.FollowerId)
                .HasMaxLength(40)
                .HasColumnName("follower_id");
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

            entity.HasIndex(e => e.CourseId, "course_id");

            entity.HasIndex(e => e.FeedbackId, "feedback_id");

            entity.HasIndex(e => e.LectureId, "lecture_id");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .HasColumnName("id");
            entity.Property(e => e.CourseId)
                .HasMaxLength(40)
                .HasColumnName("course_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.FeedbackId)
                .HasMaxLength(40)
                .HasColumnName("feedback_id");
            entity.Property(e => e.LectureId)
                .HasMaxLength(40)
                .HasColumnName("lecture_id");
            entity.Property(e => e.Type)
                .HasMaxLength(30)
                .HasColumnName("type");
            entity.Property(e => e.Url)
                .HasMaxLength(200)
                .HasColumnName("url");
            entity.Property(e => e.UserId)
                .HasMaxLength(40)
                .HasColumnName("user_id");

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

            entity.HasIndex(e => e.ChapterId, "chapter_id");

            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .HasColumnName("id");
            entity.Property(e => e.ChapterId)
                .HasMaxLength(40)
                .HasColumnName("chapter_id");
            entity.Property(e => e.CreatAt)
                .HasColumnType("datetime")
                .HasColumnName("creat_at");
            entity.Property(e => e.Index).HasColumnName("index");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TimeVideo)
                .HasColumnType("time")
                .HasColumnName("time_video");
            entity.Property(e => e.VideoUrl)
                .HasMaxLength(50)
                .HasColumnName("video_url");

            entity.HasOne(d => d.Chapter).WithMany(p => p.Lectures)
                .HasForeignKey(d => d.ChapterId)
                .HasConstraintName("Lecture_ibfk_1");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Notification");

            entity.HasIndex(e => e.CommentId, "comment_id");

            entity.HasIndex(e => e.CourseId, "course_id");

            entity.HasIndex(e => e.FeedbackId, "feedback_id");

            entity.HasIndex(e => e.ReceivedId, "received_id");

            entity.HasIndex(e => e.ReportId, "report_id");

            entity.HasIndex(e => e.SenderId, "sender_id");

            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .HasColumnName("id");
            entity.Property(e => e.CommentId)
                .HasMaxLength(40)
                .HasColumnName("comment_id");
            entity.Property(e => e.CourseId)
                .HasMaxLength(40)
                .HasColumnName("course_id");
            entity.Property(e => e.DateUp)
                .HasColumnType("datetime")
                .HasColumnName("date_up");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .HasColumnName("description");
            entity.Property(e => e.FeedbackId)
                .HasMaxLength(40)
                .HasColumnName("feedback_id");
            entity.Property(e => e.IsRead).HasColumnName("is_read");
            entity.Property(e => e.ReceivedId)
                .HasMaxLength(40)
                .HasColumnName("received_id");
            entity.Property(e => e.ReportId)
                .HasMaxLength(40)
                .HasColumnName("report_id");
            entity.Property(e => e.SenderId)
                .HasMaxLength(40)
                .HasColumnName("sender_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");

            entity.HasOne(d => d.Comment).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.CommentId)
                .HasConstraintName("Notification_ibfk_4");

            entity.HasOne(d => d.Course).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("Notification_ibfk_6");

            entity.HasOne(d => d.Feedback).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.FeedbackId)
                .HasConstraintName("Notification_ibfk_5");

            entity.HasOne(d => d.Received).WithMany(p => p.NotificationReceiveds)
                .HasForeignKey(d => d.ReceivedId)
                .HasConstraintName("Notification_ibfk_2");

            entity.HasOne(d => d.Report).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.ReportId)
                .HasConstraintName("Notification_ibfk_3");

            entity.HasOne(d => d.Sender).WithMany(p => p.NotificationSenders)
                .HasForeignKey(d => d.SenderId)
                .HasConstraintName("Notification_ibfk_1");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Payment");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.PaymendCode)
                .HasMaxLength(20)
                .HasColumnName("paymend_code");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(20)
                .HasColumnName("payment_method");
            entity.Property(e => e.Total).HasColumnName("total");
            entity.Property(e => e.UserId)
                .HasMaxLength(40)
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Payments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("Payment_ibfk_1");
        });

        modelBuilder.Entity<PaymentCourse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("PaymentCourse");

            entity.HasIndex(e => e.CartcourseId, "cartcourse_id").IsUnique();

            entity.HasIndex(e => e.PaymentId, "paymentId");

            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .HasColumnName("id");
            entity.Property(e => e.CartcourseId)
                .HasMaxLength(40)
                .HasColumnName("cartcourse_id");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(40)
                .HasColumnName("payment_id");
            entity.Property(e => e.Total).HasColumnName("total");

            entity.HasOne(d => d.Cartcourse).WithOne(p => p.PaymentCourse)
                .HasForeignKey<PaymentCourse>(d => d.CartcourseId)
                .HasConstraintName("PaymentCourse_ibfk_2");

            entity.HasOne(d => d.Payment).WithMany(p => p.PaymentCourses)
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("PaymentCourse_ibfk_1");
        });

        modelBuilder.Entity<Permisson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Permisson");

            entity.HasIndex(e => e.ResourcesId, "resources_id");

            entity.HasIndex(e => e.RoleId, "role_id");

            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .HasColumnName("id");
            entity.Property(e => e.Create).HasColumnName("create");
            entity.Property(e => e.Delete).HasColumnName("delete");
            entity.Property(e => e.LastEditor)
                .HasMaxLength(20)
                .HasColumnName("last_editor");
            entity.Property(e => e.LastUpdate)
                .HasColumnType("datetime")
                .HasColumnName("last_update");
            entity.Property(e => e.Request).HasColumnName("request");
            entity.Property(e => e.ResourcesId)
                .HasMaxLength(40)
                .HasColumnName("resources_id");
            entity.Property(e => e.RoleId)
                .HasMaxLength(40)
                .HasColumnName("role_id");
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

            entity.HasIndex(e => e.LectureId, "lecture_id");

            entity.HasIndex(e => e.QuizId, "quiz_id");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.LectureId)
                .HasMaxLength(40)
                .HasColumnName("lecture_id");
            entity.Property(e => e.QuizId)
                .HasMaxLength(40)
                .HasColumnName("quiz_id");
            entity.Property(e => e.UserId)
                .HasMaxLength(40)
                .HasColumnName("user_id");

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

            entity.HasIndex(e => e.QuizId, "quiz_id");

            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.Mark).HasColumnName("mark");
            entity.Property(e => e.QuizId)
                .HasMaxLength(40)
                .HasColumnName("quiz_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Text)
                .HasMaxLength(300)
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

            entity.HasIndex(e => e.ChapterId, "chapter_id");

            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .HasColumnName("id");
            entity.Property(e => e.ChapterId)
                .HasMaxLength(40)
                .HasColumnName("chapter_id");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.Index).HasColumnName("index");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.NumberQuestions).HasColumnName("number_questions");
            entity.Property(e => e.PassPercent).HasColumnName("pass_percent");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TotalMark).HasColumnName("total_mark");

            entity.HasOne(d => d.Chapter).WithMany(p => p.Quizzes)
                .HasForeignKey(d => d.ChapterId)
                .HasConstraintName("Quiz_ibfk_1");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Report");

            entity.HasIndex(e => e.CommentId, "comment_id");

            entity.HasIndex(e => e.CourseId, "course_id");

            entity.HasIndex(e => e.ReportedUserId, "reportedUser_id");

            entity.HasIndex(e => e.ReporterId, "reporter_id");

            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .HasColumnName("id");
            entity.Property(e => e.CommentId)
                .HasMaxLength(40)
                .HasColumnName("comment_id");
            entity.Property(e => e.CourseId)
                .HasMaxLength(40)
                .HasColumnName("course_id");
            entity.Property(e => e.Message)
                .HasMaxLength(300)
                .HasColumnName("message");
            entity.Property(e => e.ReportedUserId)
                .HasMaxLength(40)
                .HasColumnName("reportedUser_id");
            entity.Property(e => e.ReporterId)
                .HasMaxLength(40)
                .HasColumnName("reporter_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
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

            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Role");

            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<RoleUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("RoleUser");

            entity.HasIndex(e => e.RoleId, "role_id");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .HasColumnName("id");
            entity.Property(e => e.RoleId)
                .HasMaxLength(40)
                .HasColumnName("role_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");
            entity.Property(e => e.UserId)
                .HasMaxLength(40)
                .HasColumnName("user_id");

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

            entity.HasIndex(e => e.CourseId, "course_id");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .HasColumnName("id");
            entity.Property(e => e.CourseId)
                .HasMaxLength(40)
                .HasColumnName("course_id");
            entity.Property(e => e.Time)
                .HasColumnType("datetime")
                .HasColumnName("time");
            entity.Property(e => e.UserId)
                .HasMaxLength(40)
                .HasColumnName("user_id");

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

            entity.HasIndex(e => e.QuizId, "quiz_id");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Grade).HasColumnName("grade");
            entity.Property(e => e.IsPass).HasColumnName("is_pass");
            entity.Property(e => e.QuizId)
                .HasMaxLength(40)
                .HasColumnName("quiz_id");
            entity.Property(e => e.UserId)
                .HasMaxLength(40)
                .HasColumnName("user_id");

            entity.HasOne(d => d.Quiz).WithMany(p => p.Submissions)
                .HasForeignKey(d => d.QuizId)
                .HasConstraintName("Submission_ibfk_1");

            entity.HasOne(d => d.User).WithMany(p => p.Submissions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("Submission_ibfk_2");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Transaction");

            entity.HasIndex(e => e.AffiliatePaymentId, "affiliate_payment_id");

            entity.HasIndex(e => e.DepositWithdrawalId, "deposit_withdrawal_id");

            entity.HasIndex(e => e.PaymentId, "payment_id");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .HasColumnName("id");
            entity.Property(e => e.AffiliatePaymentId)
                .HasMaxLength(40)
                .HasColumnName("affiliate_payment_id");
            entity.Property(e => e.DepositWithdrawalId)
                .HasMaxLength(40)
                .HasColumnName("deposit_withdrawal_id");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(40)
                .HasColumnName("payment_id");
            entity.Property(e => e.UserId)
                .HasMaxLength(40)
                .HasColumnName("user_id");

            entity.HasOne(d => d.AffiliatePayment).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.AffiliatePaymentId)
                .HasConstraintName("Transaction_ibfk_3");

            entity.HasOne(d => d.DepositWithdrawal).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.DepositWithdrawalId)
                .HasConstraintName("Transaction_ibfk_1");

            entity.HasOne(d => d.Payment).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("Transaction_ibfk_4");

            entity.HasOne(d => d.User).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("Transaction_ibfk_2");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("User");

            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.IsVisible).HasColumnName("is_visible");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
            entity.Property(e => e.Wallet).HasColumnName("wallet");
        });

        modelBuilder.Entity<UserCertification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("UserCertification");

            entity.HasIndex(e => e.CertificationId, "certification_id");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .HasColumnName("id");
            entity.Property(e => e.CertificationId)
                .HasMaxLength(40)
                .HasColumnName("certification_id");
            entity.Property(e => e.DatePass)
                .HasColumnType("datetime")
                .HasColumnName("date_pass");
            entity.Property(e => e.UserId)
                .HasMaxLength(40)
                .HasColumnName("user_id");

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
