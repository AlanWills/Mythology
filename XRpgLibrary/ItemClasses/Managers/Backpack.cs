using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XXRpgLibrary.ItemClasses
{
    public class Backpack
    {
        #region Properties and Fields

        public List<GameItem> Items
        {
            get;
            private set;
        }

        public int Capacity
        {
            get { return Items.Count; }
        }

        #endregion

        public Backpack()
        {
            Items = new List<GameItem>();
        }

        #region Methods

        public void AddItem(GameItem gameItem)
        {
            Items.Add(gameItem);
        }

        public void RemoveItem(GameItem gameItem)
        {
            Items.Remove(gameItem);
        }

        #endregion

        #region Virtual Methods

        #endregion
    }
}
