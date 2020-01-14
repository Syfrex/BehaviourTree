using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BHTREE
{
    public class Selector : Routine
    {
        private Routine currentRoutine;
        List<Routine> AllRoutines = new List<Routine>();
        int ActiveRoutine = 0;

        public override void Start()
        {
            base.Start();
            currentRoutine = AllRoutines[ActiveRoutine];
            currentRoutine.Start();
        }
        public void AddRoutine(Routine routine)
        {
            AllRoutines.Add(routine);
        }
        public override void Reset()
        {
            ActiveRoutine = 0;
        }
        public override void RunRoutine()
        {
            if (currentRoutine.isFailed())
            {
                Failed();
                Reset();
                return;
            }
            currentRoutine.RunRoutine();

           
            if (currentRoutine.isSuccess())
            {
                if(ActiveRoutine + 1 >= AllRoutines.Count)
                {
                    Success();
                    routines = currentRoutine.GetCurrentState();
                }
                else
                {
                    ActiveRoutine++;
                    currentRoutine = AllRoutines[ActiveRoutine];
                    currentRoutine.Start();
                }
            }
        }
    }
}