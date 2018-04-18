using Forum.App.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.App.Commands
{
    class PreviousPageCommand : ICommand
    {
        private ISession session;

        public PreviousPageCommand(ISession session)
        {
            this.session = session;
        }

        public IMenu Execute(params string[] args)
        {
            var currentMenu = session.CurrentMenu;

            if(currentMenu is IPaginatedMenu paginationMenu)
            {
                paginationMenu.ChangePage(false);
            }

            return currentMenu;
        }
    }
}
