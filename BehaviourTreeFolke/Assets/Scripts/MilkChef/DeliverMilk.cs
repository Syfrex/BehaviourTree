using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BHTREE
{
    public class DeliverMilk : Routine
    {
        AICharacter DeliverObject;
        AICharacter Self;
        float HurryUpChef = 0;

        public DeliverMilk(AICharacter pancakechef, AICharacter selftarget)
        {
            DeliverObject = pancakechef;
            Self = selftarget;
        }
        public override void RunRoutine()
        {
            HurryUpChef += Time.deltaTime;

            if (!GoToObject(Self, DeliverObject))
            {
                Self.Idle = true;
                Debug.Log("Deliver complete");
                DeliverObject.Inventory.Add(1);
                Success();
                Reset();
                return;
            }
            else if (HurryUpChef > 10)
            {
                Failed();
                Reset();
                return;
            }
        }
        public override void Reset()
        {
            HurryUpChef = 0;

        }
        public bool GoToObject(AICharacter currentcharacter, AICharacter TargetObject)
        {
            currentcharacter.transform.position = Vector3.MoveTowards(currentcharacter.transform.position, TargetObject.transform.position, currentcharacter.AIMovementSpeed * Time.deltaTime);
            return Vector3.Distance(currentcharacter.transform.position, TargetObject.transform.position) > 2;
        }

    }
}
