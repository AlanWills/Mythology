using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary.CharacterClasses
{
    public class AttributePair
    {
        #region Properties and Fields

        public int CurrentValue
        {
            get;
            private set;
        }

        public int MaximumValue
        {
            get;
            private set;
        }

        public static AttributePair Zero
        {
            get { return new AttributePair(); }
        }

        #endregion

        private AttributePair()
        {
            
        }

        public AttributePair(int maxValue)
        {
            CurrentValue = maxValue;
            MaximumValue = maxValue;
        }

        #region Methods

        public void Heal(ushort value)
        {
            CurrentValue += value;
            if (CurrentValue > MaximumValue)
                CurrentValue = MaximumValue;
        }

        public void Damage(ushort value)
        {
            CurrentValue -= value;
            if (CurrentValue < 0)
                CurrentValue = 0;
        }

        public void SetCurrentValue(int value)
        {
            CurrentValue = value;
            if (CurrentValue > MaximumValue)
                CurrentValue = MaximumValue;
        }

        public void SetMaximum(int value)
        {
            MaximumValue = value;
            if (CurrentValue > MaximumValue)
                CurrentValue = MaximumValue;
        }

        #endregion
    }
}
