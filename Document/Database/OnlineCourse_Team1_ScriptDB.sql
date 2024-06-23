CREATE SCHEMA `CourseOnl`;

USE `CourseOnl`;

CREATE TABLE `User` (
  `id` varchar(20) character set utf8mb4,
  `username` varchar(50) character set utf8mb4,
  `email` varchar(50) character set utf8mb4,
  `password` varchar(50) character set utf8mb4,
  `description` varchar(300) character set utf8mb4,
  `phone` varchar(20) character set utf8mb4,
  `create_at` datetime,
  `wallet` float,
  `is_visible` boolean,
  PRIMARY KEY (`id`)
);

CREATE TABLE `RoleUser` (
  `id` varchar(20) character set utf8mb4,
  `role_id` varchar(20) character set utf8mb4,
  `user_id` varchar(20) character set utf8mb4,
  `update_date` datetime,
  `status` int,
  PRIMARY KEY (`id`)
);

CREATE TABLE `Role` (
  `id` varchar(20) character set utf8mb4,
  `name` varchar(50) character set utf8mb4,
  PRIMARY KEY (`id`)
);

CREATE TABLE `Course` (
  `id` varchar(20) character set utf8mb4,
  `name` varchar(50) character set utf8mb4,
  `description` varchar(500) character set utf8mb4,
  `create_at` datetime,
  `update_at` datetime,
  `price` float,
  `user_id` varchar(20) character set utf8mb4,
  `status` int,
  `is_visible` boolean,
  `rating` float,
  PRIMARY KEY (`id`)
);

CREATE TABLE `Chapter` (
  `id` varchar(20) character set utf8mb4,
  `index` int,
  `course_id` varchar(20) character set utf8mb4,
  `name` varchar(50) character set utf8mb4,
  `description` varchar(300) character set utf8mb4,
  `create_at` datetime,
  `status` int,
  PRIMARY KEY (`id`)
);

CREATE TABLE `Lecture` (
  `id` varchar(20) character set utf8mb4,
  `index` int,
  `chapter_id` varchar(20) character set utf8mb4,
  `name` varchar(50) character set utf8mb4,
  `time_video` time,
  `video_url` varchar(50) character set utf8mb4,
  `creat_at` datetime,
  `status` int,
  PRIMARY KEY (`id`)
);

CREATE TABLE `Quiz` (
  `id` varchar(20) character set utf8mb4,
  `index` int,
  `chapter_id` varchar(20) character set utf8mb4,
  `name` varchar(50) character set utf8mb4,
  `pass_percent` int,
  `create_at` datetime,
  `number_questions` int,
  `total_mark` int,
  `status` int,
  PRIMARY KEY (`id`)
);

CREATE TABLE `Question` (
  `id` varchar(20) character set utf8mb4,
  `quiz_id` varchar(20) character set utf8mb4,
  `text` varchar(300) character set utf8mb4,
  `mark` int,
  `type` boolean,
  `create_at` datetime,
  `status` int,
  PRIMARY KEY (`id`)
);

CREATE TABLE `Answer` (
  `id` varchar(20) character set utf8mb4,
  `question_id` varchar(20) character set utf8mb4,
  `text` varchar(300) character set utf8mb4,
  `status` int,
  `is_correct` boolean,
  `createdAt` datetime,
  PRIMARY KEY (`id`)
);

CREATE TABLE `Category` (
  `id` varchar(20) character set utf8mb4,
  `name` varchar(50) character set utf8mb4,
  PRIMARY KEY (`id`)
);

CREATE TABLE `CategoryCourse` (
  `id` varchar(20) character set utf8mb4,
  `category_id` varchar(20) character set utf8mb4,
  `course_id` varchar(20) character set utf8mb4,
  `created_at` datetime,
  PRIMARY KEY (`id`)
);

CREATE TABLE `SaveCourse` (
  `id` varchar(20) character set utf8mb4,
  `course_id` varchar(20) character set utf8mb4,
  `user_id` varchar(20) character set utf8mb4,
  `time` datetime,
  PRIMARY KEY (`id`)
);

CREATE TABLE `Notification` (
  `id` varchar(20) character set utf8mb4,
  `received_id` varchar(20) character set utf8mb4,
  `sender_id` varchar(20) character set utf8mb4,
  `title` varchar(100) character set utf8mb4,
  `description` varchar(300) character set utf8mb4,
  `date_up` datetime,
  `is_read` boolean,
  `type` varchar(50) character set utf8mb4,
  `course_id` varchar(20) character set utf8mb4,
  `feedback_id` varchar(20) character set utf8mb4,
  `comment_id` varchar(20) character set utf8mb4,
  `report_id` varchar(20) character set utf8mb4,
  `status` int,
  PRIMARY KEY (`id`)
);

CREATE TABLE `Follow` (
  `id` varchar(20) character set utf8mb4,
  `follower_id` varchar(20) character set utf8mb4,
  `followed_id` varchar(20) character set utf8mb4,
  `time` datetime,
  PRIMARY KEY (`id`)
);

CREATE TABLE `Cart` (
  `id` varchar(20) character set utf8mb4,
  `user_id` varchar(20) character set utf8mb4,
  `date_created` datetime,
  `total` float,
  `status` int,
  PRIMARY KEY (`id`)
);

CREATE TABLE `CartCourse` (
  `id` varchar(20) character set utf8mb4,
  `cart_id` varchar(20) character set utf8mb4,
  `course_id` varchar(20) character set utf8mb4,
  `affiliate_id` varchar(20) character set utf8mb4,
  `total` float,
  `created_at` datetime,
  `status` int,
  PRIMARY KEY (`id`)
);

CREATE TABLE `Payment` (
  `id` varchar(20) character set utf8mb4,
  `user_id` varchar(20) character set utf8mb4,
  `payment_method` varchar(20) character set utf8mb4,
  `paymend_code` varchar(20) character set utf8mb4,
  `create_date` datetime,
  `total` float,
  PRIMARY KEY (`id`)
);

CREATE TABLE `Image` (
  `id` varchar(20) character set utf8mb4,
  `base64Code` MEDIUMTEXT,
  `user_id` varchar(20) character set utf8mb4,
  `course_id` varchar(20) character set utf8mb4,
  `lecture_id` varchar(20) character set utf8mb4,
  `feedback_id` varchar(20) character set utf8mb4,
  `created_at` datetime,
  PRIMARY KEY (`id`)
);

CREATE TABLE `Feedback` (
  `id` varchar(20) character set utf8mb4,
  `user_id` varchar(20) character set utf8mb4,
  `title` varchar(100) character set utf8mb4,
  `description` varchar(300) character set utf8mb4,
  `is_read` boolean,
  PRIMARY KEY (`id`)
);

CREATE TABLE `EnrollCourse` (
  `id` varchar(20) character set utf8mb4,
  `user_id` varchar(20) character set utf8mb4,
  `course_id` varchar(20) character set utf8mb4,
  `date` datetime,
  PRIMARY KEY (`id`)
);

CREATE TABLE `Submission` (
  `id` varchar(20) character set utf8mb4,
  `quiz_id` varchar(20) character set utf8mb4,
  `user_id` varchar(20) character set utf8mb4,
  `grade` double,
  `date` datetime,
  `is_pass` boolean,
  PRIMARY KEY (`id`)
);

CREATE TABLE `Certification` (
  `id` varchar(20) character set utf8mb4,
  `course_id` varchar(20) character set utf8mb4 UNIQUE,
  `name` varchar(50) character set utf8mb4,
  PRIMARY KEY (`id`)
);

CREATE TABLE `UserCertification` (
  `id` varchar(20) character set utf8mb4,
  `user_id` varchar(20) character set utf8mb4,
  `certification_id` varchar(20) character set utf8mb4,
  `date_pass` datetime,
  PRIMARY KEY (`id`)
);

CREATE TABLE `Comment` (
  `id` varchar(20) character set utf8mb4,
  `course_id` varchar(20) character set utf8mb4,
  `user_id` varchar(20) character set utf8mb4,
  `rating` int,
  `comment` varchar(300) character set utf8mb4,
  `created_at` datetime,
  `is_visible` boolean,
  PRIMARY KEY (`id`)
);

CREATE TABLE `Processing` (
  `id` varchar(20) character set utf8mb4,
  `user_id` varchar(20) character set utf8mb4,
  `lecture_id` varchar(20) character set utf8mb4,
  `quiz_id` varchar(20) character set utf8mb4,
  `create_at` datetime,
  PRIMARY KEY (`id`)
);

CREATE TABLE `Report` (
  `id` varchar(20) character set utf8mb4,
  `course_id` varchar(20) character set utf8mb4,
  `comment_id` varchar(20) character set utf8mb4,
  `reportedUser_id` varchar(20) character set utf8mb4,
  `reporter_id` varchar(20) character set utf8mb4,
  `title` varchar(100) character set utf8mb4,
  `message` varchar(300) character set utf8mb4,
  `status` int,
  PRIMARY KEY (`id`)
);

CREATE TABLE `Resources` (
  `id` varchar(20) character set utf8mb4,
  `name` varchar(50) character set utf8mb4,
  PRIMARY KEY (`id`)
);

CREATE TABLE `Permisson` (
  `id` varchar(20) character set utf8mb4,
  `role_id` varchar(20) character set utf8mb4,
  `resources_id` varchar(20) character set utf8mb4,
  `last_update` datetime,
  `last_editor` varchar(20) character set utf8mb4,
  `request` boolean,
  `create` boolean,
  `delete` boolean,
  `update` boolean,
  `view` boolean,
  PRIMARY KEY (`id`)
);

CREATE TABLE `Affiliate` (
  `id` varchar(20) character set utf8mb4,
  `create_at` datetime,
  `commission_percent` float,
  `create_by` varchar(20) character set utf8mb4,
  `course_id` varchar(20) character set utf8mb4,
  UNIQUE KEY unique_user_course (create_by, course_id),
  PRIMARY KEY (`id`)
);

CREATE TABLE `PaymentCourse` (
  `id` varchar(20) character set utf8mb4,
  `paymentId` varchar(20) character set utf8mb4,
  `cartcourse_id` varchar(20) character set utf8mb4 UNIQUE,
  `total` float,
  PRIMARY KEY (`id`)
);

CREATE TABLE `AffiliatePayment` (
  `id` varchar(20) character set utf8mb4,
  `user_id` varchar(20) character set utf8mb4,
  `cartcourse_id` varchar(20) character set utf8mb4,
  `total` varchar(20) character set utf8mb4,
  `create_date` datetime,
  PRIMARY KEY (`id`)
);

CREATE TABLE `DepositWithdrawal` (
  `id` varchar(20) character set utf8mb4,
  `user_id` varchar(20) character set utf8mb4,
  `type` varchar(20) character set utf8mb4,
  `transaction_method` varchar(50) character set utf8mb4,
  `total` float,
  `create_date` datetime,
  PRIMARY KEY (`id`)
);

CREATE TABLE `Transaction` (
  `id` varchar(20) character set utf8mb4,
  `user_id` varchar(20) character set utf8mb4,
  `deposit_withdrawal_id` varchar(20) character set utf8mb4,
  `affiliate_payment_id` varchar(20) character set utf8mb4,
  `payment_id` varchar(20) character set utf8mb4,
  PRIMARY KEY (`id`)
);

ALTER TABLE `Chapter` ADD FOREIGN KEY (`course_id`) REFERENCES `Course` (`id`);

ALTER TABLE `Lecture` ADD FOREIGN KEY (`chapter_id`) REFERENCES `Chapter` (`id`);

ALTER TABLE `Quiz` ADD FOREIGN KEY (`chapter_id`) REFERENCES `Chapter` (`id`);

ALTER TABLE `Question` ADD FOREIGN KEY (`quiz_id`) REFERENCES `Quiz` (`id`);

ALTER TABLE `Answer` ADD FOREIGN KEY (`question_id`) REFERENCES `Question` (`id`);

ALTER TABLE `CategoryCourse` ADD FOREIGN KEY (`course_id`) REFERENCES `Course` (`id`);

ALTER TABLE `CategoryCourse` ADD FOREIGN KEY (`category_id`) REFERENCES `Category` (`id`);

ALTER TABLE `Course` ADD FOREIGN KEY (`user_id`) REFERENCES `User` (`id`);

ALTER TABLE `SaveCourse` ADD FOREIGN KEY (`user_id`) REFERENCES `User` (`id`);

ALTER TABLE `SaveCourse` ADD FOREIGN KEY (`course_id`) REFERENCES `Course` (`id`);

ALTER TABLE `Follow` ADD FOREIGN KEY (`follower_id`) REFERENCES `User` (`id`);

ALTER TABLE `Follow` ADD FOREIGN KEY (`followed_id`) REFERENCES `User` (`id`);

ALTER TABLE `Notification` ADD FOREIGN KEY (`sender_id`) REFERENCES `User` (`id`);

ALTER TABLE `Notification` ADD FOREIGN KEY (`received_id`) REFERENCES `User` (`id`);


ALTER TABLE `CartCourse` ADD FOREIGN KEY (`cart_id`) REFERENCES `Cart` (`id`);

ALTER TABLE `CartCourse` ADD FOREIGN KEY (`course_id`) REFERENCES `Course` (`id`);

ALTER TABLE `Cart` ADD FOREIGN KEY (`user_id`) REFERENCES `User` (`id`);

ALTER TABLE `Image` ADD FOREIGN KEY (`user_id`) REFERENCES `User` (`id`);

ALTER TABLE `Image` ADD FOREIGN KEY (`course_id`) REFERENCES `Course` (`id`);

ALTER TABLE `Image` ADD FOREIGN KEY (`lecture_id`) REFERENCES `Lecture` (`id`);

ALTER TABLE `Image` ADD FOREIGN KEY (`feedback_id`) REFERENCES `Feedback` (`id`);

ALTER TABLE `Feedback` ADD FOREIGN KEY (`user_id`) REFERENCES `User` (`id`);

ALTER TABLE `EnrollCourse` ADD FOREIGN KEY (`user_id`) REFERENCES `User` (`id`);

ALTER TABLE `EnrollCourse` ADD FOREIGN KEY (`course_id`) REFERENCES `Course` (`id`);

ALTER TABLE `Submission` ADD FOREIGN KEY (`quiz_id`) REFERENCES `Quiz` (`id`);

ALTER TABLE `Submission` ADD FOREIGN KEY (`user_id`) REFERENCES `User` (`id`);

ALTER TABLE `RoleUser` ADD FOREIGN KEY (`role_id`) REFERENCES `Role` (`id`);

ALTER TABLE `RoleUser` ADD FOREIGN KEY (`user_id`) REFERENCES `User` (`id`);

ALTER TABLE `Certification` ADD FOREIGN KEY (`course_id`) REFERENCES `Course` (`id`);

ALTER TABLE `UserCertification` ADD FOREIGN KEY (`certification_id`) REFERENCES `Certification` (`id`);

ALTER TABLE `UserCertification` ADD FOREIGN KEY (`user_id`) REFERENCES `User` (`id`);

ALTER TABLE `Comment` ADD FOREIGN KEY (`course_id`) REFERENCES `Course` (`id`);

ALTER TABLE `Comment` ADD FOREIGN KEY (`user_id`) REFERENCES `User` (`id`);

ALTER TABLE `Processing` ADD FOREIGN KEY (`user_id`) REFERENCES `User` (`id`);

ALTER TABLE `Processing` ADD FOREIGN KEY (`lecture_id`) REFERENCES `Lecture` (`id`);

ALTER TABLE `Processing` ADD FOREIGN KEY (`quiz_id`) REFERENCES `Quiz` (`id`);

ALTER TABLE `Report` ADD FOREIGN KEY (`reportedUser_id`) REFERENCES `User` (`id`);

ALTER TABLE `Report` ADD FOREIGN KEY (`comment_id`) REFERENCES `Comment` (`id`);

ALTER TABLE `Report` ADD FOREIGN KEY (`course_id`) REFERENCES `Course` (`id`);

ALTER TABLE `Report` ADD FOREIGN KEY (`reporter_id`) REFERENCES `User` (`id`);

ALTER TABLE `Permisson` ADD FOREIGN KEY (`role_id`) REFERENCES `Role` (`id`);

ALTER TABLE `Affiliate` ADD FOREIGN KEY (`create_by`) REFERENCES `User` (`id`);

ALTER TABLE `Affiliate` ADD FOREIGN KEY (`course_id`) REFERENCES `Course` (`id`);

ALTER TABLE `Permisson` ADD FOREIGN KEY (`resources_id`) REFERENCES `Resources` (`id`);

ALTER TABLE `CartCourse` ADD FOREIGN KEY (`affiliate_id`) REFERENCES `Affiliate` (`id`);

ALTER TABLE `Payment` ADD FOREIGN KEY (`user_id`) REFERENCES `User` (`id`);

ALTER TABLE `PaymentCourse` ADD FOREIGN KEY (`paymentId`) REFERENCES `Payment` (`id`);

ALTER TABLE `PaymentCourse` ADD FOREIGN KEY (`cartcourse_id`) REFERENCES `CartCourse` (`id`);

ALTER TABLE `AffiliatePayment` ADD FOREIGN KEY (`cartcourse_id`) REFERENCES `CartCourse` (`id`);

ALTER TABLE `AffiliatePayment` ADD FOREIGN KEY (`user_id`) REFERENCES `User` (`id`);

ALTER TABLE `DepositWithdrawal` ADD FOREIGN KEY (`user_id`) REFERENCES `User` (`id`);

ALTER TABLE `Transaction` ADD FOREIGN KEY (`deposit_withdrawal_id`) REFERENCES `DepositWithdrawal` (`id`);

ALTER TABLE `Transaction` ADD FOREIGN KEY (`user_id`) REFERENCES `User` (`id`);

ALTER TABLE `Transaction` ADD FOREIGN KEY (`affiliate_payment_id`) REFERENCES `AffiliatePayment` (`id`);

ALTER TABLE `Transaction` ADD FOREIGN KEY (`payment_id`) REFERENCES `Payment` (`id`);

ALTER TABLE `Notification` ADD FOREIGN KEY (`report_id`) REFERENCES `Report` (`id`);

ALTER TABLE `Notification` ADD FOREIGN KEY (`comment_id`) REFERENCES `Comment` (`id`);

ALTER TABLE `Notification` ADD FOREIGN KEY (`feedback_id`) REFERENCES `Feedback` (`id`);

ALTER TABLE `Notification` ADD FOREIGN KEY (`course_id`) REFERENCES `Course` (`id`);
