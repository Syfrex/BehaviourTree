using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BHTREE
{
    public class AskforIngridients : Routine
    {
        AICharacter Milkchef;
        AICharacter Eggchef;
        GameObject DeliverObject;
        AICharacter Self;
        float HurryUpChef = 0;
        public AskforIngridients(GameObject objectTarget, AICharacter selftarget, AICharacter eggchef, AICharacter milkchef)
        {
            DeliverObject = objectTarget;
            Self = selftarget;
            Milkchef = milkchef;
            Eggchef = eggchef;
        }
        public override void RunRoutine()
        {


            HurryUpChef += Time.deltaTime;
            if (Self.Inventory.Count > 0 && Self.InventoryTwo.Count > 0)
            {
               
                Success();
                Reset();
                return;
            }
            else
            {
                Debug.Log(Self.Inventory.Count);
                if(Self.InventoryTwo.Count <= 0)
                {

                    Debug.Log("Askfor MILK");

                    AskforMilk();
                }
                Debug.Log(Self.InventoryTwo.Count);
                if (Self.Inventory.Count <= 0)
                {

                    Debug.Log("Askfor EGG");

                    AskforEgg();
                }
            }
            if (HurryUpChef > 10)
            {
                Failed();
                Reset();
                return;
            }
        }
        public void AskforMilk()
        {

            if (Milkchef.Idle == true)
            {

                Milkchef.Idle = false;
            }
        }
        public void AskforEgg()
        {
            if (Eggchef.Idle == true)
            {
                Eggchef.Idle = false;
            }
        }
        public override void Reset()
        {
            HurryUpChef = 0;
        }


    }
}
