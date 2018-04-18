using Forum.App.Contracts;

namespace Forum.App.Commands
{
    class NextPageCommand : ICommand
    {
        private ISession session;

        public NextPageCommand(ISession session)
        {
            this.session = session;
        }

        public IMenu Execute(params string[] args)
        {
            var currentMenu = this.session.CurrentMenu;

            if(currentMenu is IPaginatedMenu paginatedMenu)
            {
                 paginatedMenu.ChangePage();
            }

            return currentMenu;
        }
    }
}
