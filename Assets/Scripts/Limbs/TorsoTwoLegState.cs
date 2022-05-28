﻿using System.Linq;

namespace FictionalOctoDoodle.Core
{
    public class TorsoTwoLegState : LimbAssemblyState
    {
        public override bool AddLimb(LimbData limb)
        {
            if (!limb.Slots.Contains(LimbSlot.FrontArm)) return false;

            context.AssembleLimb(limb, LimbSlot.FrontArm);
            context.ChangeState(new OneArmTwoLegState());
            return true;
        }

        public override bool RemoveLimb(LimbSlot limb)
        {
            if (limb != LimbSlot.FrontLeg || limb != LimbSlot.BackLeg)
            {
                return false;
            }

            context.RemoveLimb(limb);
            context.ChangeState(new TorsoOneLegState());
            return true;
        }
    }
}

