using Microsoft.Xna.Framework;
using XRpgLibrary.SkillClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using XXRpgLibrary;
using XXRpgLibrary.CharacterClasses;
using XXRpgLibrary.Controls;

namespace Mythology.GameScreens
{
    internal class SkillLabelSet
    {
        internal Label Label;
        internal Label SkillLabel;
        internal LinkLabel LinkLabel;
        internal int SkillValue;

        internal SkillLabelSet(Label label, Label skillLabel, LinkLabel linkLabel)
        {
            Label = label;
            SkillLabel = skillLabel;
            LinkLabel = linkLabel;
            SkillValue = 0;
        }
    }

    public class SkillScreen : BaseScreen
    {
        #region Properties and Fields

        private int skillPoints;
        public int SkillPoints
        {
            get { return skillPoints; }
            set
            {
                skillPoints = value;
                unassignedPoints = value;
            }
        }

        int unassignedPoints;

        Character target;
        Label pointsRemaining;

        List<SkillLabelSet> skillLabels = new List<SkillLabelSet>();
        Stack<string> undoSkill = new Stack<string>();
        EventHandler linkLabelHandler;

        #endregion

        public SkillScreen(GameStateManager stateManager, int skillPoints)
            : base(stateManager)
        {
            linkLabelHandler = new EventHandler(addSkillLabel_Selected);
            SkillPoints = skillPoints;

            SetTarget(GamePlayScreen.Player.Character);
        }
        
        #region Methods

        public void SetTarget(Character character)
        {
            target = character;

            foreach (SkillLabelSet set in skillLabels)
            {
                set.SkillValue = character.Entity.Skills[set.Label.Text].SkillValue;
                set.SkillLabel.Text = set.SkillValue.ToString();
            }
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            CreateControls();
        }

        private void CreateControls()
        {
            AddBackground("Backgrounds\\MainMenu");

            float padding = ControlManager.SpriteFont.LineSpacing + 10f;

            string skillPath = Content.RootDirectory + "\\Game\\Skills";
            string[] skillFiles = Directory.GetFiles(skillPath, "*.xnb");

            for (int i = 0; i < skillFiles.Length; i++)
                skillFiles[i] = "Game\\Skills\\" + Path.GetFileNameWithoutExtension(skillFiles[i]);

            List<SkillData> skillData = new List<SkillData>();

            Vector2 nextControlPosition = new Vector2(300, 150);
            pointsRemaining = new Label("Skill Points: " + unassignedPoints.ToString(), nextControlPosition);
            ControlManager.Add(pointsRemaining);

            nextControlPosition.Y += padding;

            foreach (string s in skillFiles)
            {
                SkillData data = Content.Load<SkillData>(s);

                Label label = new Label(data.Name, nextControlPosition);
                label.Type = data.Name;
                ControlManager.Add(label);

                Label sLabel = new Label("0", new Vector2(nextControlPosition.X + 300, nextControlPosition.Y));
                ControlManager.Add(sLabel);

                LinkLabel linkLabel = new LinkLabel("+", new Vector2(nextControlPosition.X + 350, nextControlPosition.Y));
                linkLabel.Type = data.Name;
                linkLabel.Selected += addSkillLabel_Selected;
                ControlManager.Add(linkLabel);

                nextControlPosition.Y += padding;
                skillLabels.Add(new SkillLabelSet(label, sLabel, linkLabel));
            }

            nextControlPosition.Y += padding;

            LinkLabel undoLabel = new LinkLabel("Undo", nextControlPosition);
            undoLabel.Selected += new EventHandler(undoLabel_Selected);
            ControlManager.Add(undoLabel);

            nextControlPosition.Y += padding;

            LinkLabel acceptLabel = new LinkLabel("Accept Changes", nextControlPosition);
            acceptLabel.Selected += new EventHandler(acceptLabel_Selected);
            ControlManager.Add(acceptLabel);

            ControlManager.NextControl();
        }

        void acceptLabel_Selected(object sender, EventArgs e)
        {
            undoSkill.Clear();
            Transition(new GamePlayScreen(StateManager), ChangeType.Change);
        }

        void undoLabel_Selected(object sender, EventArgs e)
        {
            if (unassignedPoints == skillPoints)
                return;

            string skillName = undoSkill.Peek();
            undoSkill.Pop();
            unassignedPoints++;

            foreach (SkillLabelSet set in skillLabels)
            {
                if (set.LinkLabel.Type == skillName)
                {
                    set.SkillValue--;
                    set.SkillLabel.Text = set.SkillValue.ToString();
                    target.Entity.Skills[skillName].DecreaseSkill(1);
                }
            }

            pointsRemaining.Text = "Skill Points: " + unassignedPoints.ToString();
        }

        void addSkillLabel_Selected(object sender, EventArgs e)
        {
            if (unassignedPoints <= 0)
                return;

            string skillName = ((LinkLabel)sender).Type;
            undoSkill.Push(skillName);
            unassignedPoints--;

            foreach (SkillLabelSet set in skillLabels)
            {
                if (set.LinkLabel.Type == skillName)
                {
                    set.SkillValue++;
                    set.SkillLabel.Text = set.SkillValue.ToString();
                    target.Entity.Skills[skillName].IncreaseSkill(1);
                }
            }

            pointsRemaining.Text = "Skill Points: " + unassignedPoints.ToString();
        }

        #endregion

        #region Virtual Methods

        #endregion
    }
}
