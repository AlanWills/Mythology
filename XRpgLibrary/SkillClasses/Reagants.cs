using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary.SkillClasses
{
    public struct Reagents
    {
        #region Properties and Fields

        public string ReagantName;
        public ushort AmountRequired;

        #endregion

        public Reagents(string reagant, ushort number)
        {
            ReagantName = reagant;
            AmountRequired = number;
        }

        #region Methods

        #endregion

        #region Virtual Methods

        #endregion
    }

    public class Recipe
    {
        #region Properties and Fields

        public string Name
        {
            get;
            private set;
        }

        public Reagents[] Reagents
        {
            get;
            private set;
        }

        #endregion

        public Recipe(string name, params Reagents[] reagents)
        {
            Name = name;
            Reagents = new Reagents[reagents.Length];

            for (int i = 0; i < reagents.Length; i++)
                Reagents[i] = reagents[i];
        }

        #region Methods

        #endregion

        #region Virtual Methods

        #endregion
    }
}
