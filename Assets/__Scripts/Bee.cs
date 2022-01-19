using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BeeConstants
{
      public const float MaxEnergy=200f;
      public const float MaxNectar=100f;
}
public class Bee : BeeStateMachine
{
    [SerializeField] public float energy = 100f;
    public float nectar;

    [SerializeField] public Transform hive;

    [SerializeField] private float range;
    [SerializeField] public float moveSpeed = 2f;

    private int randomRose;

    public SpriteRenderer spriteRenderer;

    public Collider2D collider;

    private void Start()
    {   
        energy=BeeConstants.MaxEnergy;
        spriteRenderer=GetComponent<SpriteRenderer>();
        collider=GetComponent<Collider2D>();
        nectar=0f;
        transform.position = hive.transform.position;
        SetState(new BeeAtHive(this));
    

    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Bird")){
            if(State is BeeSearching){
                Debug.Log("Caught");
                Destroy(this);
            }
            
        }
    }
    private void Update()
    {
       State.Update();
    }

    private void PickRose()
    {
        randomRose = Random.Range(0, SpawnFlowers.Instance.spawnedRoses.Count);
    }
    private void CollectNectar()
    {
        energy -= 0.1f;
        transform.position = Vector2.MoveTowards(transform.position, SpawnFlowers.Instance.spawnedRoses[randomRose].transform.position, moveSpeed * Time.deltaTime);
    }

    private void ReturnToHive()
    {

    }
}
