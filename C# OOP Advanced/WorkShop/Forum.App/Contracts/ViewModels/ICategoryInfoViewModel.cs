using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.App.Contracts
{
    public interface ICategoryInfoViewModel
    {
        int Id { get; }

        string Name { get; }

        int PostCount { get; }
    }
}
