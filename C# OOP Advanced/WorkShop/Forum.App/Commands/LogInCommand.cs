using Forum.App.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.App.Commands
{
    public class LogInCommand : ICommand
    {
        private IUserService userService;
        private IMenuFactory menuFctory;

        public LogInCommand(IUserService userService, IMenuFactory menuFctory)
        {
            this.userService = userService;
            this.menuFctory = menuFctory;
        }

        public IMenu Execute(params string[] args)
        {
            string username = args[0];
            string password = args[1];

            bool success = userService.TryLogInUser(username, password);

            if (!success)
            {
                throw new InvalidOperationException("Invalid Login!");
            }

            return menuFctory.CreateMenu("MainMenu");
        }
    }
}
