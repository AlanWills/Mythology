using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary.EffectClasses
{
    public class Weakness
    {
        #region Properties and Fields

        public DamageType WeaknessType
        {
            get;
            private set;
        }

        private int amount;
        public int Amount
        {
            get { return amount; }
            private set
            {
                if (value < 0)
                    amount = 0;
                else if (value > 100)
                    amount = 100;
                else
                    amount = value;
            }
        }

        #endregion
        
        public Weakness(WeaknessData data)
        {
            WeaknessType = data.WeaknessType;
            Amount = data.Amount;
        }

        #region Methods

        public int Apply(int damage)
        {
            return (damage + (int)(damage * amount / 100f));
        }

        #endregion

        #region Virtual Methods

        #endregion
    }
}
