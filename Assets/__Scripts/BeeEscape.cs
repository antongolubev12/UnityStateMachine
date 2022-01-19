using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeEscape : BeeState
{
    public BeeEscape(Bee bee) : base(bee)
    {

    }

    public override void Start()
    {
        bee.spriteRenderer.color=Color.black;
    }

    public override void Update()
    {
        if (bee.transform.position != bee.hive.position)
        {
            bee.energy-=0.3f;
            bee.transform.position = Vector2.MoveTowards(bee.transform.position,
                  bee.hive.position,
                  bee.moveSpeed * Time.deltaTime);
        }
        else{
            bee.SetState(new BeeAtHive(bee));
        }
    }

    private void CheckEnergy(){
        if(bee.energy<=BeeConstants.MaxEnergy*.6f){
            bee.spriteRenderer.color=Color.yellow;
            if(bee.energy<=BeeConstants.MaxEnergy*.3f){
                bee.spriteRenderer.color=Color.red;
            }
        }
    }
}