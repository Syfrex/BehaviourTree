using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BHTREE
{
    public class GetMilk : Routine
    {
        GameObject DeliverObject;
        AICharacter Self;
        float HurryUpChef = 0;
        public GetMilk(GameObject objectTarget, AICharacter selftarget)
        {
            DeliverObject = objectTarget;
            Self = selftarget;
        }
        public override void RunRoutine()
        {
            
            HurryUpChef += Time.deltaTime;
            if (!GoToObject(Self, DeliverObject))
            {
                
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
        public bool GoToObject(AICharacter currentcharacter, GameObject TargetObject)
        {
            currentcharacter.transform.position = Vector3.MoveTowards(currentcharacter.transform.position, TargetObject.transform.position, currentcharacter.AIMovementSpeed * Time.deltaTime);
            return Vector3.Distance(currentcharacter.transform.position, TargetObject.transform.position) > 2;
        }


    }
}
