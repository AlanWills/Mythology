using RpgLibrary.TrapClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class Chest : BaseItem
    {
        #region Properties and Fields

        static Random Random = new Random();
        ChestData chestData;

        public bool IsLocked
        {
            get { return chestData.IsLocked; }
        }

        public bool IsTrapped
        {
            get { return chestData.IsTrapped; }
        }

        public int Gold
        {
            get
            {
                if (chestData.MinGold == 0 && chestData.MaxGold == 0)
                    return 0;

                int gold = Random.Next(chestData.MinGold, chestData.MaxGold);
                chestData.MinGold = 0;
                chestData.MaxGold = 0;

                return gold;
            }
        }

        #endregion

        public Chest(ChestData data)
            : base(data.Name, "", 0, 0)
        {
            chestData = data;
        }

        #region Methods

        #endregion

        #region Virtual Methods

        public override object Clone()
        {
            ChestData data = new ChestData();
            data.Name = chestData.Name;
            data.DifficultyLevel = chestData.DifficultyLevel;
            data.IsLocked = chestData.IsLocked;
            data.IsTrapped = chestData.IsTrapped;
            data.TrapName = chestData.TrapName;
            data.KeyName = chestData.KeyName;
            data.KeyType = chestData.KeyType;
            data.KeysRequired = chestData.KeysRequired;
            data.MinGold = chestData.MinGold;
            data.MaxGold = chestData.MaxGold;

            foreach (KeyValuePair<string, string> item in chestData.ItemCollection)
                data.ItemCollection.Add(item.Key, item.Value);

            Chest chest = new Chest(data);
            return chest;
        }

        #endregion
    }
}
