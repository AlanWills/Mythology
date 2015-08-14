using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XRpgLibrary.CharacterClasses;
using XXRpgLibrary.EffectClasses;

namespace XRpgLibrary.EffectClasses
{
    public class HealEffect : BaseEffect
    {
        #region Properties and Fields

        HealType healType;
        Mechanics.DieType dieType;
        int numberOfDice;
        int modifier;

        #endregion

        private HealEffect()
        {

        }

        #region Methods

        public static HealEffect FromHealEffectData(HealEffectData data)
        {
            HealEffect effect = new HealEffect();

            effect.healType = data.HealType;
            effect.dieType = data.DieType;
            effect.numberOfDice = data.NumberOfDice;
            effect.modifier = data.Modifier;

            return effect;
        }

        #endregion

        #region Virtual Methods

        public override void Apply(Entity entity)
        {
            int amount = modifier;

            for (int i = 0; i < numberOfDice; i++)
                amount += Mechanics.RollDie(dieType);

            if (amount < 1)
                amount = 1;

            switch (healType)
            {
                case HealType.Health:
                    entity.Health.Heal((ushort)amount);
                    break;
                case HealType.Mana:
                    entity.Mana.Heal((ushort)amount);
                    break;
                case HealType.Stamina:
                    entity.Stamina.Heal((ushort)amount);
                    break;
            }
        }

        #endregion
    }
}
