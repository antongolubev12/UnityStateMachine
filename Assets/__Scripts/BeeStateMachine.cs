using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Implementing the state pattern. Allows for clean transitions between states.
//Creating a state machine which stores a state object, and making Bee derive from the state machine allows us to remove ugly switch and if statements and avoid a god class in class Bee.
//Instead of switching behaviour based on an enum state/variable state in one big god class, we can delagate behaviour to each individual state class.
//We just have to specify the conditions on which to change states.
//This lets the code look a lot cleaner and more readable.
//The same reasoning obviously applies to the BirdStateMachine
public abstract class BeeStateMachine : MonoBehaviour { 
    protected BeeState State;
    
    public void SetState(BeeState state){
        State= state;
        State.Start();
    }

    public BeeState GetState(){
        return State;
    }
}