using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BeeDancing : BeeState
{   
    private Vector3 left;
    private Vector3 right;
    private float phase = 0;
    private float speed = 1; 
    private float phaseDirection = 1;

    public BeeDancing(Bee bee) : base(bee)
    {

    }
    // Start is called before the first frame update
    public override void Start()
    {
        bee.spriteRenderer.color = Color.red;
    }

    public override void Update()
    {
        if (bee.transform.position != bee.hive.position)
        {
            bee.transform.position = Vector2.MoveTowards(bee.transform.position,
                  bee.hive.position,
                  bee.moveSpeed * Time.deltaTime);
        }
        else
        {
            left=new Vector3(bee.transform.position.x, bee.transform.position.y-10, bee.transform.position.z);
            right=new Vector3(bee.transform.position.x, bee.transform.position.y+10, bee.transform.position.z);
           Dance();
            bee.nectar-=0.2f;
            if(bee.nectar<=0f){
                bee.nectar=0f;
                bee.SetState(new BeeAtHive(bee));
            }
        }
    }

    private void Dance(){
        if(bee.nectar>=BeeConstants.MaxNectar*.75){
            Move(300);
        }
        else if(bee.nectar>=BeeConstants.MaxNectar*.5){
            Move(-300);
        }
        else if(bee.nectar>=BeeConstants.MaxNectar*.25){
            Move(300);
        }
        else if(bee.nectar<=BeeConstants.MaxNectar*.25 && bee.nectar>0){
            Move(-300);
        }
        
        
    }

    private void Move(int move){
        bee.transform.position = Vector2.MoveTowards(bee.transform.position,
                  new Vector3(bee.transform.position.x+move,bee.transform.position.y,bee.transform.position.z),
                  bee.moveSpeed * Time.deltaTime);
    }
}