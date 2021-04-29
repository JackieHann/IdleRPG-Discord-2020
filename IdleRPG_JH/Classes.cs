using IdleRPG_JH.Bots;
using IdleRPG_JH.Bots.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdleRPG_JH.Classes
{
    public enum ClassTypes
    {
        None,
        Assassin,
        Warrior,
        Paladin,
        Ranger,
        Mage
    }

    public enum ArmourTypes
    { 
        Heavy,
        Medium,
        Light
    }

    public enum WeaponTypes
    {
        Dagger,
        Sword,
        Light
    }

    public enum HandRestriction
    { 
        MainHand,
        Offhand,
        TwoHand
    }

    public enum BodyRestriction
    { 
        Head,
        Body,
        Waist,
        Legs,
        Feet,
        Hands,
    }

    public class Classes
    {
        public static Classes GetClassForType(ClassTypes type)
        {
            switch (type)
            {
                case ClassTypes.Warrior:    return new Warrior();
                case ClassTypes.Ranger:     return new Ranger();
                case ClassTypes.Mage:       return new Mage();
                case ClassTypes.Assassin:   return new Assassin();
                case ClassTypes.Paladin:    return new Paladin();
            }

            return new Classes();
        }

        public static string GetStringForType(ClassTypes type)
        {
            switch (type)
            {
                case ClassTypes.Warrior: return "Warrior";
                case ClassTypes.Ranger: return "Ranger";
                case ClassTypes.Mage: return "Mage";
                case ClassTypes.Assassin: return "Assassin";
                case ClassTypes.Paladin: return "Paladin";
            }

            return "None";
        }

        public ClassTypes ClassType { get; protected set; }
        public List<WeaponTypes> EquippableWeaponTypes;
        public List<ArmourTypes> EquippableArmourTypes;

        public Classes()
        {
            ClassType = ClassTypes.None;
        }

        public virtual bool CanEquipWeapon(Weapon weapon)
        {
            foreach (WeaponTypes t in EquippableWeaponTypes)
            {
                if (t == weapon.WeaponType)
                    return true;
            }

            return false;
        }

        public virtual bool CanEquipArmour(Armour armour)
        {
            foreach (ArmourTypes t in EquippableArmourTypes)
            {
                if (t == armour.ArmourType)  return true;
            }
            return false;
        }

        public virtual int AlterDamageTaken(int taken)
        {
            return taken;
        }

        public virtual int AlterDamageGiven(int given)
        {
            return given;
        }

    }
}
