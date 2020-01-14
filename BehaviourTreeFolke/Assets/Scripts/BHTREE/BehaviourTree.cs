using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BHTREE
{
    public class BehaviourTree : MonoBehaviour
    {

        public Routine Tree;
        public GameObject Chicken, Cow, Oven;
        public AICharacter Milkchef, Eggchef, Pancakechef;
        List<GameObject> Pancakes = new List<GameObject>();
        public enum AIType
        {
            EggChef,
            MilkChef,
            PancakeChef
        }
        public AIType AItype;

        public void CreateTree()
        {
            if (AItype == AIType.EggChef)
            {

                EggChef Egghandler = new EggChef(Pancakechef, Chicken, Eggchef);
                Selector EggSelector = new Selector();
                GrabEgg GrabbingEggSquence = new GrabEgg(Chicken, Eggchef);
                DeliverEgg DeliverEggSquence = new DeliverEgg(Pancakechef, Eggchef);

                EggSelector.AddRoutine(Egghandler);
                EggSelector.AddRoutine(GrabbingEggSquence);
                EggSelector.AddRoutine(DeliverEggSquence);
                Repeating EggRepeater = new Repeating(EggSelector, 100);

                Tree = EggRepeater;

            }
            else if (AItype == AIType.MilkChef)
            {

                MilkChef Milkhandler = new MilkChef(Pancakechef, Cow, Milkchef);
                Selector MilkSelector = new Selector();
                GetMilk GrabbingMilkSquence = new GetMilk(Cow, Milkchef);
                DeliverMilk DeliverMilkSquence = new DeliverMilk(Pancakechef, Milkchef);

                MilkSelector.AddRoutine(Milkhandler);
                MilkSelector.AddRoutine(GrabbingMilkSquence);
                MilkSelector.AddRoutine(DeliverMilkSquence);

                Repeating MilkRepeater = new Repeating(MilkSelector, 100);

                Tree = MilkRepeater;
            }
            else if (AItype == AIType.PancakeChef)
            {
                PancakeChef pancakechef = new PancakeChef(Oven, Pancakechef);
                Selector PancakeSelector = new Selector();
                AskforIngridients askforIngridience = new AskforIngridients(Oven, Pancakechef, Milkchef, Eggchef);
                Cook cook = new Cook(Pancakechef);

                PancakeSelector.AddRoutine(pancakechef);
                PancakeSelector.AddRoutine(askforIngridience);
                PancakeSelector.AddRoutine(cook);

                Repeating PancakeRepeater = new Repeating(PancakeSelector, 100);
                Tree = PancakeRepeater;
            }

        }
        

    }
}