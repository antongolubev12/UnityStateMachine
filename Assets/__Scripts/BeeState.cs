using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Abstract for the state of the bee. Any bee states will implement this class.
//Constructor allows the passing of the bee object between states.
public abstract class BeeState : MonoBehaviour { 
    protected Bee bee;

    public BeeState(Bee bee){
        this.bee=bee;
    }
    public virtual void Start(){

    }

    public virtual void Update(){
        
    }
 
}