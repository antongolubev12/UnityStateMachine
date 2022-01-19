using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class BirdState : MonoBehaviour { 
    protected Bird bird;

    public BirdState(Bird bird){
        this.bird=bird;
    }
    public virtual void Start(){

    }

    public virtual void Update(){
        
    }
 
}