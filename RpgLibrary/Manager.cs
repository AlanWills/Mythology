using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary
{
    public class Manager<T>
    {
        public Dictionary<string, T> Dictionary
        {
            get;
            private set;
        }

        public Manager()
        {
            Dictionary = new Dictionary<string, T>();
        }

    }
}
