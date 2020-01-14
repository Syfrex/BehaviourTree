using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BHTREE
{ 
public class Repeating : Routine {

    private int RepeatTimes;
    private int OriginalTimes;
    private Routine CurrentRoutine;


    public Repeating(Routine routine, int AmountToRepeat)
    {
        base.Start();
        CurrentRoutine = routine;
        RepeatTimes = AmountToRepeat;
        OriginalTimes = AmountToRepeat;

    }
    public void Start()
    {
        base.Start();
        CurrentRoutine.Start();
    }
    public override void Reset()
    {
        RepeatTimes = OriginalTimes;
    }
    public override void RunRoutine()
    {
        if (CurrentRoutine.isFailed())
        {
            Failed();
            Reset();
            return;
        }
        else if (CurrentRoutine.isSuccess())
        {
            if (RepeatTimes == 0)
            {
                Success();
                Reset();
                return;
            }
            if (RepeatTimes > 0 || RepeatTimes <= -1)
            {
                RepeatTimes--;
                CurrentRoutine.Reset();
                CurrentRoutine.Start();
            }


        }
        if (CurrentRoutine.isRunning())
        {
            CurrentRoutine.RunRoutine();
        }
    }
}
}