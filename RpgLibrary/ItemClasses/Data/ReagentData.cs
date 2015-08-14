using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class ReagentData
    {
        public string Name;
        public string Type;
        public int Price;
        public float Weight;

        public ReagentData()
        {

        }

        public override string ToString()
        {
            string reagentString = Name + ", ";
            reagentString += Type + ", ";
            reagentString += Price.ToString() + ", ";
            reagentString += Weight.ToString();

            return reagentString;
        }
    }
}
