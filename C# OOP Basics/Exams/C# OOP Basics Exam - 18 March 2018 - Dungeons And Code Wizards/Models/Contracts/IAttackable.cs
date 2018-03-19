using DungeonsAndCodeWizards.Models.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Contracts
{
    public interface IAttackable
    {
        void Attack(Character character);
    }
}
