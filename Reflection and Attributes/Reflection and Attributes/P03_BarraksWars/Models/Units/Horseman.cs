using System;
using System.Collections.Generic;
using System.Text;

namespace _03BarracksFactory.Models.Units
{
    class Horseman : Unit
    {
        private const int DefaultHealth = 25;
        private const int DefaultDamage = 7;

        public Horseman()
            : base(DefaultHealth, DefaultDamage)
        {
        }
    }
}
