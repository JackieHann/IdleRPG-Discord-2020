using IdleRPG_JH.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdleRPG_JH.Bots.Class
{
    public class Assassin : IdleRPG_JH.Classes.Classes
    {
        public Assassin()
{
            ClassType = ClassTypes.Assassin;
            EquippableArmourTypes.Add(ArmourTypes.Medium);

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
