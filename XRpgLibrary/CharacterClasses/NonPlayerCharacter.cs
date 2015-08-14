using XRpgLibrary.CharacterClasses;
using XRpgLibrary.ConversationClasses;
using XRpgLibrary.QuestClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XXRpgLibrary.SpriteClasses;

namespace XXRpgLibrary.CharacterClasses
{
    public class NonPlayerCharacter : Character
    {
        #region Properties and Fields

        public List<Conversation> Conversations
        {
            get;
            private set;
        }

        public List<Quest> Quests
        {
            get;
            private set;
        }

        public bool HasConversation
        {
            get { return Conversations.Count > 0; }
        }

        public bool HasQuest
        {
            get { return Quests.Count > 0; }
        }

        #endregion

        public NonPlayerCharacter(Entity entity, AnimatedSprite sprite)
            : base(entity, sprite)
        {
            Conversations = new List<Conversation>();
            Quests = new List<Quest>();
        }

        #region Methods

        #endregion

        #region Virtual Methods

        #endregion
    }
}
