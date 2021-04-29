using IdleRPG_JH.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdleRPG_JH.Bots.Class
{
    public class Paladin : IdleRPG_JH.Classes.Classes
    {
        public Paladin()
{
            ClassType = ClassTypes.Paladin;
            EquippableWeaponTypes.Add(WeaponTypes.Sword);
        }

        public override int AlterDamageTaken(int taken)
        {
            return taken;
        }

        public override int AlterDamageGiven(int given)
        {
            return given;
        }
    }
}
