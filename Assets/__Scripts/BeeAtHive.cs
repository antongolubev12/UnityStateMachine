using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//state class derived from bee state
//retrieves passed bee object from the base constructor
public class BeeAtHive : BeeState
{
    private int waypointIndex = 0;
    private bool atHive=false;

    public BeeAtHive(Bee bee) : base(bee)
    {

    }

    public override void Start()
    {
        bee.spriteRenderer.color=Color.yellow;
    }

    public override void Update()
    {
        if (bee.transform.position != bee.hive.position)
        {
            bee.transform.position = Vector2.MoveTowards(bee.transform.position,
                  bee.hive.position,
                  bee.moveSpeed * Time.deltaTime);
        }else{
            bee.energy+=0.3f;
        }
        if(bee.transform.position == bee.hive.position && bee.energy>=BeeConstants.MaxEnergy){
            bee.energy=BeeConstants.MaxEnergy;
            bee.SetState(new BeeSearching(bee));
        }
    }
}