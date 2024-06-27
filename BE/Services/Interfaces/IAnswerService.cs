using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Models;

namespace BE.Services.Interfaces
{
    public interface IAnswerService
    {
        Task<List<Answer>> GetAllDataOfAnswerFromQuizById(string quizId);
    }
}