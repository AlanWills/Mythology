using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class Reagent : BaseItem
    {
        #region Properties and Fields

        #endregion

        public Reagent(string reagentName, string reagentType, int price, float weight)
            : base(reagentName, reagentType, price, weight)
        {

        }

        #region Methods

        #endregion

        #region Virtual Methods

        public override object Clone()
        {
            Reagent reagent = new Reagent(Name, Type, Price, Weight);

            return reagent;
        }

        #endregion
    }
}
