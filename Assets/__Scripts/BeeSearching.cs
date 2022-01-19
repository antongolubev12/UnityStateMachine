using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BeeSearching : BeeState
{
    private int randomRose;

    public BeeSearching(Bee bee) : base(bee)
    {

    }

    public override void Start()
    {
        bee.spriteRenderer.color=Color.green;
        randomRose = Random.Range(0, SpawnFlowers.Instance.spawnedRoses.Count);
    }

    public override void Update() { 
        //move bee toward picked flower
        if(bee.transform.position!=SpawnFlowers.Instance.spawnedRoses[randomRose].transform.position){
            //Debug.Log("bee position: "+bee.transform.position);
            //Debug.Log("rose position: "+SpawnFlowers.Instance.spawnedRoses[randomRose].transform.position);
            bee.transform.position = Vector2.MoveTowards(bee.transform.position, SpawnFlowers.Instance.spawnedRoses[randomRose].transform.position, bee.moveSpeed * Time.deltaTime);
            bee.energy-=.1f;
        }
        else{
            Debug.Log("On rose");
            bee.SetState(new BeeCollect(bee));
        }
    }
}