using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class ItemManager
    {
        #region Item Dictionaries

        Dictionary<string, Weapon> weapons = new Dictionary<string, Weapon>();
        Dictionary<string, Armour> armours = new Dictionary<string, Armour>();
        Dictionary<string, Shield> shields = new Dictionary<string, Shield>();

        public Dictionary<string, Weapon>.KeyCollection WeaponKeys
        {
            get { return weapons.Keys; }
        }

        public Dictionary<string, Armour>.KeyCollection ArmourKeys
        {
            get { return armours.Keys; }
        }

        public Dictionary<string, Shield>.KeyCollection ShieldKeys
        {
            get { return shields.Keys; }
        }

        #endregion

        public ItemManager()
        {

        }

        #region Weapon Methods

        public bool ContainsWeapon(string name)
        {
            return weapons.ContainsKey(name);
        }

        public void AddWeapon(Weapon weapon)
        {
            if (!ContainsWeapon(weapon.Name))
            {
                weapons.Add(weapon.Name, weapon);
            }
        }

        public Weapon GetWeapon(string name)
        {
            if (ContainsWeapon(name))
            {
                return (Weapon)weapons[name].Clone();
            }

            return null;
        }

        #endregion

        #region Armour Methods

        public bool ContainsArmour(string name)
        {
            return armours.ContainsKey(name);
        }

        public void AddArmour(Armour armour)
        {
            if (!ContainsArmour(armour.Name))
            {
                armours.Add(armour.Name, armour);
            }
        }

        public Armour GetArmour(string name)
        {
            if (ContainsArmour(name))
            {
                return (Armour)armours[name].Clone();
            }

            return null;
        }

        #endregion

        #region Shield Methods

        public bool ContainsShield(string name)
        {
            return shields.ContainsKey(name);
        }

        public void AddShield(Shield shield)
        {
            if (!ContainsShield(shield.Name))
            {
                shields.Add(shield.Name, shield);
            }
        }

        public Shield GetShield(string name)
        {
            if (ContainsShield(name))
            {
                return (Shield)shields[name].Clone();
            }

            return null;
        }

        #endregion
    }
}
