using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFly : BirdState
{
    private int pathIndex=0;
    private bool loop;

    public BirdFly(Bird bird) : base(bird)
    {

    }
    // Start is called before the first frame update
    public override void Start()
    {   
        bird.spriteRenderer.color=Color.green;

        // Set position of Bird as position of the first waypoint
        bird.transform.position = bird.waypoints[pathIndex].transform.position;
    }

    // Update is called once per frame
    public override void Update()
    {
        if (pathIndex <= bird.waypoints.Length - 1)
        {
            if (bird.energy > 3)
            {
                bird.transform.position = Vector2.MoveTowards(bird.transform.position,
                   bird.waypoints[pathIndex].transform.position,
                   bird.moveSpeed * Time.deltaTime);

                if (bird.transform.position == bird.waypoints[pathIndex].transform.position)
                {
                    pathIndex += 1;
                }
                bird.energy-=0.4f;
            }
            else{
                bird.SetState(new BirdRest(bird));
            }
        }
        else if(pathIndex==bird.waypoints.Length){
            bird.transform.position = Vector2.MoveTowards(bird.transform.position,
                   bird.nest.position,
                   bird.moveSpeed * Time.deltaTime);
        }

    }

    
}