using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BHTREE
{
    public class Cook : Routine
    {

        AICharacter Self;
        float HurryUpChef = 0;
        bool Cooking = false;
        float CookTime = 0;

        public Cook(AICharacter selftarget)
        {
            Self = selftarget;
            CookTime = 0;
        }
        public override void RunRoutine()
        {

            HurryUpChef += Time.deltaTime;
            if (Self.Inventory.Count > 0 && Self.InventoryTwo.Count > 0 && Cooking == false)
            {
                Cooking = true;
                Self.Inventory.RemoveAt(Self.Inventory.Count - 1);
                Self.InventoryTwo.RemoveAt(Self.InventoryTwo.Count - 1);

            }
            else if (HurryUpChef > 10)
            {
                Failed();
                Reset();
                return;
            }
            if(Cooking)
            {
                CookTime += Time.deltaTime;
                if(CookTime > 5)
                {
                    Self.IncreacePancakes();
                    Self.SpawnPancake();
                    Success();
                    Reset();
                    return;
                }
            }
        }
        public override void Reset()
        {
            HurryUpChef = 0;
            CookTime = 0;
            Cooking = false;
        }



    }
}
