using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreateObjectsFurkan : MonoBehaviour {

    // *** instantiate function parameters are going to be revised 

    public GameObject[] obstacles;
    public GameObject[] foods;
    public GameObject airCapsule;


    private int numberOfVariousObstacles; // baglama, cell phone, elektrik supurgesi, screw, vosvos = 5 , can always be increased
    private int consequentObstaclesSpawned = 0, consequentFoodsSpawned = 0, consequentAirSpawned = 0;


    // Use this for initialization
    void Start () {
        InvokeRepeating("ObjectSpawner", .5f, 3.5f);
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void ObjectSpawner()
    {
        int randomObject = Random.Range(0, 2);
        if (consequentObstaclesSpawned == 0)        // the last object was a boost
        {
            SpawnRandomObstacle();
        }
        else if (consequentObstaclesSpawned == 2)   // the last two objects were obstacles
        {
            SpawnRandomBoost();
        }
        else                                        // the last object was an obstacle
        {
            switch(randomObject)
            {
                case 0:
                    SpawnRandomBoost();
                    break;
                case 1:
                    SpawnRandomObstacle();
                    break;
            }
        }
    }

    private void SpawnRandomObstacle()
    {
        int randomObstacle = Random.Range(0, obstacles.Length);
        Spawn(obstacles[randomObstacle]);
        consequentObstaclesSpawned++;
        consequentFoodsSpawned = 0; consequentAirSpawned = 0;
    }

    private void SpawnRandomBoost()
    {
        int randomBoost = Random.Range(0, 2); //food or air
        
        // boost will be either food or air
        // after 2 consequent foods, air will spawn
        // after 2 consequent air objects, food will spawn
        if (consequentFoodsSpawned == 2)
        {
            SpawnAirObject();
        }
        else if (consequentAirSpawned == 2)
        {
            SpawnFood();
        }
        else
        {
            switch (randomBoost)
            {
                case 0:
                    SpawnAirObject();
                    break;
                case 1:
                    SpawnFood();
                    break;
            }
        }
        consequentObstaclesSpawned = 0;
    }
    
    void SpawnAirObject()
    {
        Spawn(airCapsule);
        consequentAirSpawned++;
        consequentFoodsSpawned = 0;
    }
         
    void SpawnFood()
    {
        int randomFood = Random.Range(0, foods.Length); //food1 or food2
        Spawn(foods[randomFood]);
        consequentFoodsSpawned++;
        consequentAirSpawned = 0;
	}

    void Spawn(GameObject objectSpawning)
    {
        float randomx = Random.Range(-3f, 3f);
        GameObject myObject = Instantiate(objectSpawning, new Vector3(randomx,-6f,0f), Quaternion.identity );
        myObject.AddComponent<Rigidbody>();
        myObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 5f, 0f);
        myObject.GetComponent<Rigidbody>().useGravity = false;
    }

    }
