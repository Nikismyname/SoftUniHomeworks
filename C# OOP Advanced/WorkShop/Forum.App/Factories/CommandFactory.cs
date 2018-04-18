namespace Forum.App.Factories
{
	using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandFactory : ICommandFactory
	{
        private IServiceProvider serviceProvider;

        public CommandFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public ICommand CreateCommand(string commandName)
		{
            var commandType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == commandName + "Command");

            if(commandType == null)
            {
                throw new InvalidOperationException("Command not found!");
            }

            if (!typeof(ICommand).IsAssignableFrom(commandType))
            {
                throw new InvalidOperationException($"{commandType} in not a Command!");
            }

            var contructorParams = commandType.GetConstructors().First().GetParameters();

            var args = new object[contructorParams.Length];

            for (int i = 0; i < contructorParams.Length; i++)
            {
                args[i] = this.serviceProvider.GetService(contructorParams[i].ParameterType);
            }

            var command = (ICommand)Activator.CreateInstance(commandType, args);

            return command;
		}
	}
}
