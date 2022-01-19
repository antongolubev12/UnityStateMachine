using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFlowers : MonoBehaviour
{
    private static SpawnFlowers _instance;

    public static SpawnFlowers Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
    
    [SerializeField] private int numberOfRoses;
    [SerializeField] GameObject rose;
    
    [SerializeField] private Transform[] spawnPoints;

    public List <GameObject> spawnedRoses = new List<GameObject>();

    // Start is called before the first frame update
    void OnEnable()
    {   
        //spawnedRoses= new GameObject[numberOfRoses];
        for(int i=0;i<=numberOfRoses;i++)
        {   
            int randomSpawn=Random.Range(0,spawnPoints.Length); 

            GameObject spawnedObj= Instantiate(rose, spawnPoints[randomSpawn].position,Quaternion.identity);
            spawnedObj.transform.position = new Vector3(spawnedObj.transform.position.x, spawnedObj.transform.position.y, 0);
            spawnedRoses.Add(spawnedObj);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
