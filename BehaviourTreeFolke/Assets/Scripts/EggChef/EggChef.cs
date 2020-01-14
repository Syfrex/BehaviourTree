using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BHTREE
{
    public class EggChef : Routine
    {
        AICharacter Pancakechef;
        GameObject Chicken;
        AICharacter thischaracter;
        float timer = 0;


        public EggChef(AICharacter pancakechef, GameObject chicken, AICharacter selftarget)
        {
            Pancakechef = pancakechef;
            Chicken = chicken;
            thischaracter = selftarget;
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
