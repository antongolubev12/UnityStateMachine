using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdRest : BirdState
{
    public BirdRest(Bird bird) : base(bird)
    {

    }
    // Start is called before the first frame update
    public override void Start()
    {
        bird.spriteRenderer.color=Color.yellow;
    }

    // Update is called once per frame
    public override void Update()
    {
        if (bird.transform.position != bird.nest.position)
        {
            bird.transform.position = Vector2.MoveTowards(bird.transform.position,
                bird.nest.position,
                bird.moveSpeed * Time.deltaTime);
        }
        else
        {
            bird.energy += .3f;
            if (bird.energy >= BirdConstants.MaxEnergy)
            {
                bird.spriteRenderer.color = Color.green;
                bird.energy = BirdConstants.MaxEnergy;
                bird.SetState(new BirdFly(bird));
            }
        }

    }
}
