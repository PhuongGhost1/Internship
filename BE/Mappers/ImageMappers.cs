using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.ImageD;
using BE.Models;

namespace BE.Mappers
{
    public static class ImageMappers
    {
        public static ImageDto ToImageData(this Image imageModel){
            return new ImageDto{
                Id = imageModel.Id,
                Base64Code = imageModel.Base64Code,
                User_Id = imageModel.UserId,
                Course_Id = imageModel.CourseId,
                Lecture_Id = imageModel.LectureId,
                Feedback_Id = imageModel.FeedbackId,
                Created_At = imageModel.CreatedAt
            };
        }
    }
}