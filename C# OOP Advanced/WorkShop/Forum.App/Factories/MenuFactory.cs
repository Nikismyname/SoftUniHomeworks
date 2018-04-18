using Forum.App.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Forum.App.Factories
{
    public class MenuFactory : IMenuFactory
    {
        private IServiceProvider serviceProvider;

        public MenuFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IMenu CreateMenu(string menuName)
        {
            var menuType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == menuName);

            if(menuType == null)
            {
                throw new InvalidOperationException("Menu not found!");
            }

            if (!typeof(IMenu).IsAssignableFrom(menuType))
            {
                throw new InvalidOperationException($"{menuType} is not a menu!");
            }

            var ctorParams = menuType.GetConstructors().First().GetParameters();
            var ctorArgs = new object[ctorParams.Length];
            for (int i = 0; i < ctorParams.Length; i++)
            {
                ctorArgs[i] = this.serviceProvider.GetService(ctorParams[i].ParameterType);
            }

            var menu = (IMenu)Activator.CreateInstance(menuType, ctorArgs);
            return menu;


        }
    }
}
