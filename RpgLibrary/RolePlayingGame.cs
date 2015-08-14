using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary
{
    public class RolePlayingGame
    {
        #region Properties and Fields

        public string Name
        {
            get;
            private set;
        }

        public string Description
        {
            get;
            private set;
        }

        #endregion

        public RolePlayingGame()
        {

        }

        public RolePlayingGame(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
