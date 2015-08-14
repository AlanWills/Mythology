using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary
{
    public struct Modifier
    {
        #region Properties and Fields

        public string Modifying;
        public int Amount;
        public int Duration;
        public TimeSpan TimeLeft;

        #endregion

        public Modifier(string modifying, int amount)
        {
            Modifying = modifying;
            Amount = amount;
            Duration = -1;
            TimeLeft = TimeSpan.Zero;
        }

        public Modifier(string modifying, int amount, int duration)
            : this(modifying, amount)
        {
            Duration = duration;
            TimeLeft = TimeSpan.FromSeconds(duration);
        }

        #region Methods

        public void Update(TimeSpan elapsedTime)
        {
            if (Duration == -1)
                return;

            TimeLeft -= elapsedTime;
            if (TimeLeft.TotalMilliseconds < 0)
            {
                TimeLeft = TimeSpan.Zero;
                Amount = 0;
            }
        }

        #endregion

        #region Virtual Methods

        #endregion
    }
}
