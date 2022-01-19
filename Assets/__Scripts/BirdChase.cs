using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdChase : BirdState
{
    GameObject bee;
    public BirdChase(Bird bird) : base(bird)
    {

    }

    // Start is called before the first frame update
    public override void Start()
    {
        GameObject[] bees = GameObject.FindGameObjectsWithTag("Bee");
        foreach (GameObject bee in bees)
        {
            if (Vector3.Distance(bee.transform.position, bird.transform.position) <= ChaseController.Instance.range)
            {
                this.bee=bee;
            }
        }
    }

    public override void Update(){
        Chase(bee);
    }

    private void Chase(GameObject bee)
    {
        CheckEnergy();
        if(bird.energy >= BirdConstants.MaxEnergy * .1)
        {
            bird.energy-=0.8f;
            if(bee!=null){
                bird.transform.position = Vector2.MoveTowards(bird.transform.position,
                           bee.transform.position,
                           bird.moveSpeed * Time.deltaTime);
            }
        }
        else{
            bird.SetState(new BirdRest(bird));
        }
    }

    private void CheckEnergy(){
        if(bird.energy<=BirdConstants.MaxEnergy*.6f){
            bird.spriteRenderer.color=Color.yellow;
            if(bird.energy<=BirdConstants.MaxEnergy*.3f){
                bird.spriteRenderer.color=Color.red;
            }
        }
    }
}
