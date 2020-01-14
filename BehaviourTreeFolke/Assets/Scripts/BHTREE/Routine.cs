using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BHTREE
{
    public enum Routines
    {
        SUCCESS,
        FAILED,
        RUNNING
    }
    public abstract class Routine
    {
        public Routines routines;
        public Routine()
        {

        }
        public abstract void Reset();
        public abstract void RunRoutine();
        public virtual void Start()
        {
            routines = Routines.RUNNING;
        }
        public virtual void Failed()
        {
            routines = Routines.FAILED;
        }
        public virtual void Running()
        {
            routines = Routines.RUNNING;
        }
        public virtual void Success()
        {
            routines = Routines.SUCCESS;
        }
        public virtual bool isFailed()
        {
            return routines.Equals(Routines.FAILED);
        }
        public virtual bool isSuccess()
        {
            return routines.Equals(Routines.SUCCESS);
        }
        public virtual bool isRunning()
        {
            return routines.Equals(Routines.RUNNING);
        }
        public Routines GetCurrentState()
        {
            return routines;
        }


    }
}