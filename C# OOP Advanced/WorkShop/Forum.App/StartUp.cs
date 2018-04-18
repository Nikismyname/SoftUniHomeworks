namespace Forum.App
{
	using System;
	using Microsoft.Extensions.DependencyInjection;
	using Contracts;
	using Factories;
    using Forum.Data;
    using Forum.App.Services;
    using Forum.App.Models;

    public class StartUp
	{
		public static void Main(string[] args)
		{
            IServiceProvider serviceProvider = ConfigureServices();
            IMainController mainController = serviceProvider.GetService<IMainController>();

			Engine engine = new Engine(mainController);
			engine.Run();
		}

		private static IServiceProvider ConfigureServices()
		{
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<ICommandFactory, CommandFactory>();
            serviceCollection.AddSingleton<ILabelFactory, LabelFactory>();
            serviceCollection.AddSingleton<IMenuFactory, MenuFactory>();
            serviceCollection.AddSingleton<ITextAreaFactory, TextAreaFactory>();
            serviceCollection.AddSingleton<ForumData>();
            serviceCollection.AddTransient<IPostService, PostService>();
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddSingleton<ISession, Session>();
            serviceCollection.AddSingleton<IForumViewEngine, ForumViewEngine>();
            serviceCollection.AddSingleton<IMainController, MenuController>();
            serviceCollection.AddTransient<IForumReader, ForumConsoleReader>();
            return serviceCollection.BuildServiceProvider();
        }
    }
}
