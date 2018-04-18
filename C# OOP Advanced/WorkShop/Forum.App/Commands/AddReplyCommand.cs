using Forum.App.Contracts;

namespace Forum.App.Commands
{
    class AddReplyCommand : ICommand
    {
        private IMenuFactory menuFactory;

        public AddReplyCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            int id = int.Parse(args[0]);
            var commandName = this.GetType().Name;
            var menuName = commandName.Substring(0, commandName.Length-"Command".Length ) + "Menu";
            var menu = this.menuFactory.CreateMenu(menuName);
            if(menu is IIdHoldingMenu idHoldingMenu)
            {
                idHoldingMenu.SetId(id);
            }
            return menu;
        }
    }
}
