using System;
using System.Threading.Tasks;
using Weather_Assistant.Util;

namespace Weather_Assistant.Services
{
    public class UserInteractionService: IUserInteractionService
    {
        private readonly IQuestionService _questionService;
        private readonly IWeatherstackService _weatherstackService;
        public UserInteractionService(IWeatherstackService weatherstackService,
            IQuestionService questionService)
        {
            _weatherstackService = weatherstackService;
            _questionService = questionService;
        }
        public void Start()
        {
            //_weatherstackService.Hello();
            var weatherStackResponse = AskZipCode();
            AskQuestion(weatherStackResponse);
        }
        
        private WeatherStackResponse AskZipCode()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Constants.AskZipCodeMessage);
            string zipCode = Console.ReadLine();
            if (zipCode.Trim() == string.Empty)
            {
                AskZipCode();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(string.Format
              (Constants.ConfirmedZipCodeMessage, zipCode));

            var task = Task.Run(async () => await _weatherstackService.GetWeatherInfo(zipCode));
            var result = task.Result;
            if (result?.location != null)
            {
                Console.WriteLine(string.Format(Constants.ZipCodeValid,
                    result?.location.name, result?.location.country, result?.location.region));
                return result;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Constants.ZipCodeInvalid);
                return AskZipCode();
            }
        }

        private void AskQuestion(WeatherStackResponse weatherInfo)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Constants.SelectQuestionMessage);
            var questions = _questionService.GetQuestions();
            var selectedQuestion = UIUtils.PrintQuestion(questions);

            var result=  _questionService.AnswerQuestion(selectedQuestion, weatherInfo);

            if (result)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(selectedQuestion.YesMessage);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(selectedQuestion.NoMessage);
            }
            Console.WriteLine();
            AskQuestion(weatherInfo);
        }
    }
}