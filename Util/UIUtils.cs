using System;
using Weather_Assistant.DTO;

namespace Weather_Assistant.Util
{
    public static class UIUtils
    {
        public static Question PrintQuestion(Question[] questions)
        {
            int optionsCount = questions.Length;
            int selected = 0;
            bool isDone = false;

            while (!isDone)
            {
                for (int i = 0; i < optionsCount; i++)
                {
                    if (selected == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("> ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(questions[i].QuestionMessage);
                    Console.ResetColor();
                }

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        selected = Math.Max(0, selected - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        selected = Math.Min(optionsCount - 1, selected + 1);
                        break;
                    case ConsoleKey.Enter:
                        isDone = true;
                        break;
                }

                if (!isDone)
                {
                    Console.CursorTop -= optionsCount;
                }
            }
            return questions[selected];
        }
    }
}