using BE.Dto.Processing;
using BE.Models;

namespace BE.Mappers
{
    public static class ProcessingMappers
    {
        public static ProcessingDto ToProcessingData(this Processing processingModel){
            return new ProcessingDto{
                Id = processingModel.Id,
                UserId = processingModel.UserId,
                LectureId = processingModel.LectureId,
                QuizId = processingModel.QuizId,
                CreateAt = processingModel.CreateAt
            };
        }
    }
}