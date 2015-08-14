using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary.ItemClasses
{
    public class KeyData
    {
        #region Properties and Fields

        public string Name;
        public string Type;

        #endregion

        public KeyData()
        {

        }

        #region Methods

        #endregion

        #region Virtual Methods

        public override string ToString()
        {
            string keyString = Name + ", ";
            keyString += Type;

            return keyString;
        }

        #endregion
    }
}
