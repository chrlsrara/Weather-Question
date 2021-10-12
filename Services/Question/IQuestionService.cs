using Weather_Assistant.DTO;
using Weather_Assistant.Util;

namespace Weather_Assistant.Services
{
    public interface IQuestionService
    {
        Question[] GetQuestions();
        bool AnswerQuestion(Question question, WeatherStackResponse info);
    }
}
