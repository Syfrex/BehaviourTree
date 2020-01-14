using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BHTREE
{
    public class MilkChef : Routine
    {
        AICharacter Pancakechef;
        GameObject Cow;
        float timer = 0;
        AICharacter thischaracter;


        public MilkChef(AICharacter pancakechef, GameObject cow, AICharacter selftarget)
        {
            Pancakechef = pancakechef;
            thischaracter = selftarget;
            Cow = cow;
        }

        public override void Reset()
        {
            thischaracter.Inventory.RemoveAt(thischaracter.Inventory.Count - 1);
        }
        public override void RunRoutine()
        {
            if (thischaracter.Idle == false)
            {
                Success();
                return;
            }

            else if (thischaracter.Idle == true)
            {
                if (thischaracter.Inventory.Count > 0)
                {
                    Reset();
                }
                return;
            }
        }

    }
}
