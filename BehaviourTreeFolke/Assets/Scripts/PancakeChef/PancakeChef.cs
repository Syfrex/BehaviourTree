using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BHTREE
{
    public class PancakeChef : Routine
    {
        GameObject Oven;
        AICharacter thischaracter;

        float timer = 0;

        public PancakeChef(GameObject target, AICharacter selfchef)
        {
            Oven = target;
            thischaracter = selfchef;

        }
        public override void Reset()
        {
            timer = 0;
        }

        public override void RunRoutine()
        {
            if (GoToObject(thischaracter, Oven) == false)
            {
                Success();
                Reset();
                return;

            }


            timer += Time.deltaTime;
        }
        public bool GoToObject(AICharacter currentcharacter, GameObject TargetObject)
        {
            currentcharacter.transform.position = Vector3.MoveTowards(currentcharacter.transform.position, TargetObject.transform.position, currentcharacter.AIMovementSpeed * Time.deltaTime);
            return Vector3.Distance(currentcharacter.transform.position, TargetObject.transform.position) > 2;
        }
    }
}
