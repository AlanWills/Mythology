using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary.EffectClasses
{
    public class Resistance
    {
        #region Properties and Fields

        public DamageType ResistanceType
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
        
        public Resistance(ResistanceData data)
        {
            ResistanceType = data.ResistanceType;
            Amount = data.Amount;
        }

        #region Methods

        public int Apply(int damage)
        {
            return (damage - (int)(damage * amount / 100f));
        }

        #endregion

        #region Virtual Methods

        #endregion
    }
}
