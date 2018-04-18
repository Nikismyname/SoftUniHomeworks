using Forum.App.Contracts;
using Forum.App.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.App.Commands
{
    class SignUpMenuCommand : ICommand
    {
        private IMenuFactory menuFactory;

        public SignUpMenuCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            string commandName = this.GetType().Name;
            string menuName = commandName.Substring(0, commandName.Length - "Command".Length);
            var menu = this.menuFactory.CreateMenu(menuName);
            return menu;
        }
    }
}
