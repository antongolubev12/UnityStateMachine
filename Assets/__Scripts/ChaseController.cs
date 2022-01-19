using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseController : MonoBehaviour
{
    private static ChaseController _instance;

    public static ChaseController Instance { get { return _instance; } }

    [SerializeField] public float range;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    [SerializeField] private Bee[] bees;
    [SerializeField] private Bird[] birds;

    private void Update() {
        CheckBee();
    }
    private void CheckBee()
    {
        foreach (Bee bee in bees)
        {
            foreach (Bird bird in birds)
            {
                if (Vector3.Distance(bee.transform.position, bird.transform.position) <= range)
                {
                    //Debug.Log(Vector3.Distance(bee.transform.position, bird.transform.position));
                    if (bee.GetState() is BeeSearching && bird.GetState() is BirdFly)
                    {
                        Debug.Log("chasing");
                        bird.SetState(new BirdChase(bird));
                        bee.SetState(new BeeEscape(bee));
                        //if(bird.On)
                    }
                }
            }
        }
    }

}