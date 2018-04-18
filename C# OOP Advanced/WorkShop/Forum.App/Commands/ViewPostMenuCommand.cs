using Forum.App.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.App.Commands
{
    class ViewPostMenuCommand : ICommand
    {
        private IMenuFactory menuFactory;

        public ViewPostMenuCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }
        
        public IMenu Execute(params string[] args)
        {
            var categoryId = int.Parse(args[0]);
            var commandName = this.GetType().Name;
            var menuName = commandName.Substring(0, commandName.Length - "Command".Length);
            var menu = (IIdHoldingMenu)menuFactory.CreateMenu(menuName);
            menu.SetId(categoryId);
            return menu;
        }
    }
}
