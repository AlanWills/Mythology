using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.CharacterClasses
{
    public class EntityDataManager
    {
        #region Properties and Fields

        public Dictionary<string, EntityData> EntityData
        {
            get { return entityData; }
        }

        readonly Dictionary<string, EntityData> entityData = new Dictionary<string, EntityData>();

        #endregion
    }
}
