using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary.ItemClasses
{
    public class Key : BaseItem
    {
        #region Properties and Fields

        #endregion

        public Key(string name, string type)
            : base(name, type, 0, 0)
        {

        }

        #region Methods

        #endregion

        #region Virtual Methods

        public override object Clone()
        {
            Key key = new Key(this.Name, this.Type);

            return key;
        }

        #endregion
    }
}
