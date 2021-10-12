using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Weather_Assistant.Services;

namespace Weather_Assistant
{
    class Program
    {
        public static IConfigurationRoot configuration;
        static void Main()
        {
           
            // Build configuration
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            // Boostrapping the app
            var serviceProvider = new ServiceCollection()
                .AddSingleton(configuration)
                .AddSingleton<IWeatherstackService, WeatherstackService>()
                .AddSingleton<IQuestionService, QuestionService>()
                .AddSingleton<IUserInteractionService, UserInteractionService>()
                .BuildServiceProvider();


            var weatherApp = serviceProvider.GetService<IUserInteractionService>();
            // Start the App
            weatherApp.Start();
            Console.ReadKey();

        }
    }
}
