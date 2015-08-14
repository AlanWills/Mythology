using RpgLibrary.SkillClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class ChestData
    {
        public string Name;
        public DifficultyLevel DifficultyLevel;
        public bool IsTrapped;
        public bool IsLocked;
        public string TrapName;
        public string KeyName;
        public string KeyType;
        public int KeysRequired;
        public int MinGold;
        public int MaxGold;
        public Dictionary<string, string> ItemCollection;

        public ChestData()
        {
            ItemCollection = new Dictionary<string, string>();
        }

        public override string ToString()
        {
            string chestString = Name + ", ";
            chestString += DifficultyLevel.ToString() + ", ";
            chestString += IsTrapped.ToString() + ", ";
            chestString += IsLocked.ToString() + ", ";
            chestString += TrapName + ", ";
            chestString += KeyName + ", ";
            chestString += KeyType + ", ";
            chestString += KeysRequired.ToString() + ", ";
            chestString += MinGold.ToString() + ", ";
            chestString += MaxGold.ToString();

            foreach (KeyValuePair<string, string> pair in ItemCollection)
            {
                chestString += ", " + pair.Key + "+" + pair.Value;
            }

            return chestString;
        }
    }
}
