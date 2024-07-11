using BE.Dto.Course.Chapter.Quiz;
using BE.Models;

namespace BE.Mappers
{
    public static class SubmissionMappers
    {
        public static SubmissionDto ToSubmissionData(this Submission submissionModel){
            return new SubmissionDto{
                Id = submissionModel.Id,
                QuizId = submissionModel.QuizId,
                UserId = submissionModel.UserId,
                Grade = submissionModel.Grade,
                Date = submissionModel.Date,
                IsPass = submissionModel.IsPass
            };
        }
    }
}