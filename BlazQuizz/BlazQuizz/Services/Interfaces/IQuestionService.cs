using BlazQuizz.Models;

namespace BlazQuizz.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<List<QuestionModel>> GetQuestionsAsync();
    }
}