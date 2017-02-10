using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjectsFurkan : MonoBehaviour {

    // *** instantiate function parameters are going to be revised 

    //GameObject Prefabs
    public Transform obstacle1;
    public Transform obstacle2;
    public Transform obstacleLast;
    public Transform food1;
    public Transform food2; //assuming there will be 2 food objects, can always be increased
    public Transform airObject;


    private int numberOfVariousObstacles; // baglama, cell phone, elektrik supurgesi, screw, vosvos = 5 , can always be increased
    private int consequentObstaclesSpawned = 0, consequentFoodsSpawned = 0, consequentAirSpawned = 0;


    // Use this for initialization
    void Start () {
		
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
        int randomObstacle = Random.Range(0, numberOfVariousObstacles);
        switch (randomObstacle)
        {
            case 0:
                Instantiate(obstacle1);
                break;
                    // ...
                    // ...
            case 4:                         // numberOfVariousObstacles = 5
                Instantiate(obstacleLast);
                break;
        }
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
        Instantiate(airObject);
        consequentAirSpawned++;
        consequentFoodsSpawned = 0;
    }
         
    void SpawnFood()
    {
        int randomFood = Random.Range(0, 2); //food1 or food2
        switch (randomFood)
        {
            case 0:
                Instantiate(food1);
                break;
            case 1:
                Instantiate(food2);
                break;
        }
        consequentFoodsSpawned++;
        consequentAirSpawned = 0;
    }

    }
