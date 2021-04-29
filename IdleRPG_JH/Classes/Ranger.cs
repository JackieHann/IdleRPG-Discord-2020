using IdleRPG_JH.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdleRPG_JH.Bots.Class
{
    public class Ranger : IdleRPG_JH.Classes.Classes
    {
        public Ranger()
{
            ClassType = ClassTypes.Ranger;
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
