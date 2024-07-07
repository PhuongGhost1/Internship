using BE.Dto.Question;
using BE.Mappers;
using BE.Models;
using BE.Repository.Interface;
using BE.Services.Interfaces;

namespace BE.Services.Implementations
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _quesRepo;
        private readonly IQuizRepository _quizRepo;
        public QuestionService(IQuestionRepository quesRepo, IQuizRepository quizRepo)
        {
            _quesRepo = quesRepo;
            _quizRepo = quizRepo;
        }

        

        //---------------------CRUD--------------------------//
        public async Task<Question?> CreateQuestion(CreateQuestionDto createQuestionDto, string quizId)
        {
            var quiz = await _quizRepo.GetQuizById(quizId);

            if(quiz == null) throw new Exception("Unable to find quiz");

            var createQuestion = createQuestionDto.ToCreataQuestionDto(quizId);

            if(createQuestion == null) throw new Exception("Unable to create question");

            return await _quesRepo.CreateQuestion(createQuestion);
        }

        public async Task<bool> DeleteQuestion(string questionId)
        {
            var question = await _quesRepo.GetQuestionById(questionId);

            if(question == null) throw new Exception("Unable to find question!");

            return await _quesRepo.DeleteQuestion(questionId);
        }

        public async Task<List<Question>> GetAllQuestions()
        {
            return await _quesRepo.GetAllQuestions();
        }

        public async Task<Question?> UpdateQuestion(string questionId, UpdateQuestionDto updateQuestionDto)
        {
            var question = await _quesRepo.GetQuestionById(questionId);

            if(question == null) throw new Exception("Unable to find question!");

            var updateQuestion = updateQuestionDto.ToUpdateQuestionDto();

            if(updateQuestion == null) throw new Exception("Unable to update question!");

            return await _quesRepo.UpdateQuestion(updateQuestion);
        }

    }
}