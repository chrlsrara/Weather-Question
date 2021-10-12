using Microsoft.Extensions.Configuration;
using System.Linq;
using Weather_Assistant.DTO;
using Weather_Assistant.Util;

namespace Weather_Assistant.Services
{
    public class QuestionService: IQuestionService
    {
        private readonly double uvThreshold = 0;
        private readonly double windSpeed = 0;
        public QuestionService(IConfigurationRoot config)
        {
            uvThreshold = double.Parse(config.GetSection("UvThreshold").Value);
            windSpeed = double.Parse(config.GetSection("UvThreshold").Value);
        }
        public Question[] GetQuestions()
        {
            var MOCKED_QUESTIONS = new Question[]
            {
                new Question()
                {
                    QuestionMessage= "Should I go outside?",
                    QuestionType =  new EnumQuestionType[]{ EnumQuestionType.IsNotRaining },
                    YesMessage = "Yes, absolutely. There's no rain detected.",
                    NoMessage = "No. Probably not. Its raining or going to rain soon."
                },
                new Question()
                {
                    QuestionMessage= "Should I wear sunscreen?",
                    QuestionType =  new EnumQuestionType[]{ EnumQuestionType.WearSunscreen },
                    YesMessage = "Yes, Sunny is up and bright. Apply that skin care.",
                    NoMessage = "No, its not needed. Sun is hiding today, but please wear that moisturizer."
                },
                new Question()
                {
                    QuestionMessage= "Can I fly my kite?",
                    QuestionType =  new EnumQuestionType[]{ EnumQuestionType.IsNotRaining,
                    EnumQuestionType.OverWindPressure},
                    YesMessage = "Yes, Its sunny and the wind is not too strong.",
                    NoMessage = "No, you cant with this climate."
                },
            };
            return MOCKED_QUESTIONS;
        }

        public bool AnswerQuestion(Question question, WeatherStackResponse info)
        {
            return question.QuestionType.All(qtype => ValidateQuestionType(qtype, info));
        }

        private bool ValidateQuestionType(EnumQuestionType qtype, WeatherStackResponse info)
        {
            if(qtype == EnumQuestionType.IsNotRaining)
            {
                return !WeatherCodes.RainyCodes.Any(code => code == info.current.weather_code);
            }
            if (qtype == EnumQuestionType.WearSunscreen)
            {
                return info?.current.uv_index < uvThreshold;
            }
            if (qtype == EnumQuestionType.OverWindPressure)
            {
                return info?.current.wind_speed < windSpeed;
            }
            return true;
        }

    }



}
