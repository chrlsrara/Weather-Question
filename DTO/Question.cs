using Weather_Assistant.Util;

namespace Weather_Assistant.DTO
{
    public class Question
    {
        public string QuestionMessage { get; set; }
        public EnumQuestionType[] QuestionType {get; set;}

        public string YesMessage { get; set; }
        public string NoMessage { get; set; }
    }
}
