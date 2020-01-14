using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BHTREE
{
    public class AICharacter : MonoBehaviour
    {
        public List<int> Inventory = new List<int>();
        public List<int> InventoryTwo = new List<int>();
        public static int AmountofPancakes = 0;

        public GameObject Pancake;
        public bool Idle = true;
        public float AIMovementSpeed = 1;
        public BehaviourTree Behaviour;
        public void IncreacePancakes()
        {
            AmountofPancakes++;
        }
        public void SpawnPancake()
        {
            Instantiate(Pancake, transform.position + ((Vector3.up * AmountofPancakes) / 2), transform.rotation);
        }

        
        void Awake()
        {
            AmountofPancakes = 0;
            Behaviour = GetComponent<BehaviourTree>();
            if (Behaviour != null)
            {
                Behaviour.CreateTree();
                if (Behaviour.Tree != null)
                    Behaviour.Tree.Start();
            }

        }
        public void Update()
        {

            if (Behaviour.Tree != null)
            {

                Behaviour.Tree.RunRoutine();
            }

        }

        public void SetIdle(bool idlestate)
        {
            Idle = idlestate;
        }
        public bool GetIdle()
        {
            return Idle;
        }

    }
}