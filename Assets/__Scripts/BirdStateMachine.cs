using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class BirdStateMachine : MonoBehaviour { 
    protected BirdState State;
    public void SetState(BirdState state){
        State= state;
        State.Start();
    }

    public BirdState GetState(){
        return State;
    }
}