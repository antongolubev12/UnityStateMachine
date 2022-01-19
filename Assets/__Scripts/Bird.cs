using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BirdConstants
{
      public const float MaxEnergy=500f;
}
public class Bird : BirdStateMachine
{
    [SerializeField] public float energy;
    [SerializeField] public Transform nest;

    [SerializeField] public Transform[] waypoints;

    // Walk speed that can be set in Inspector
    [SerializeField] public float moveSpeed = 2f;
    
    public SpriteRenderer spriteRenderer;

    public Collider2D collider;

    // Index of current waypoint from which Enemy walks
    // to the next one
    private int waypointIndex = 0;

    //private int Max

	// Use this for initialization
	private void Start () {
        energy=BirdConstants.MaxEnergy;
        collider=GetComponent<Collider2D>();
        spriteRenderer=GetComponent<SpriteRenderer>();
        SetState(new BirdRest(this));
	}
	
	// Update is called once per frame
	private void Update () {
        State.Update();
	}

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Bee")){
            energy=BirdConstants.MaxEnergy;
        }
    }

    
}
