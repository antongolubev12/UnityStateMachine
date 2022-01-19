using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeCollect : BeeState
{
    public BeeCollect(Bee bee) : base(bee)
    {

    }

    public override void Start()
    {
        bee.spriteRenderer.color=Color.blue;
    }

    public override void Update()
    {
        if(bee.nectar<=BeeConstants.MaxNectar){
            bee.nectar+=1f;
        }
        else{
            bee.SetState(new BeeDancing(bee));
        }
       
    }
}