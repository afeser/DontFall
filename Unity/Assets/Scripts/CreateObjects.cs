using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjects : MonoBehaviour {


    /*
     * THIS IS THE CREATOR SCRIPT
     * THE AIM IS TO CREATE OBJECTS AND INSTANTIATE THEM WITH APPROPRIATE PARAMETERS LIKE POSITION, ROTATION, ETC...
     * SOMETIMES LIFETIME ATTRIBUTES CAN BE STORED HERE IF THEY ARE REQUIRED ( OR WANTED ) WHILE INSTANTIATING SUCH AS ANGULAR SPEED
     */
    public GameObject[] gameObjects;
    public int objectSpawnSpeedInMilliseconds = 500; // Time between spawn of objects in milli seconds
    public GameObject background; // Spawn range info
    public float spawnPosition; // just outside the screen (y value)
    public float maxInitialSpeed,minInitialSpeed; // Max initialize speed
    public float maxDistractionAngle; // Initial distraction of objects ( 90 means totally horizontal )
    public float maxRotationSpeed; // Angular rotation speed
    public float objectSizeMultiplier; // How many times the objects will be bigger-smaller


    private bool continueProducing = true;

	void Start () {
        StartCoroutine(SpawnObjects());

        // - Furkan
            //initializing variables
            //or are we going to initialize them inside the unity editor
            //I get it :)
        // - Furkan
        
	}
	
	void Update () {
		
	}

    
    IEnumerator SpawnObjects() {
        //Instantiating with random orientation and ranged position
        int rand1 = (int)Random.Range(0.0f, gameObjects.Length);
        GameObject myObject = Instantiate(gameObjects[rand1],
            /*Random position between the ranges*/
            new Vector3(Random.Range(-background.transform.localScale.x / 2, background.transform.localScale.x / 2), spawnPosition, 0),
            /*From a random direction to another random direction*/
            Quaternion.FromToRotation(new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)), new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360))));
        
        // Adding linear speed
        myObject.AddComponent<Rigidbody>();
        float randomAngle = Random.Range(-maxDistractionAngle,maxDistractionAngle);
        float randomSpeed = Random.Range(minInitialSpeed, maxInitialSpeed);
        myObject.GetComponent<Rigidbody>().velocity = new Vector3(randomSpeed * Mathf.Sin(randomAngle * Mathf.PI / 180), randomSpeed * Mathf.Cos(randomAngle * Mathf.PI / 180), 0);

        // Adding angular speed
        myObject.GetComponent<Rigidbody>().angularVelocity = (new Vector3(maxRotationSpeed * Random.Range(0, 360), maxRotationSpeed * Random.Range(0, 360), maxRotationSpeed * Random.Range(0, 360)));

        // Disabling gravity
        myObject.GetComponent<Rigidbody>().useGravity = false;

        // Adding garbage collector script
        myObject.AddComponent<ObjectGarbageCollector>();

        // Resizing objects
        myObject.transform.localScale = myObject.transform.localScale * objectSizeMultiplier;


        // Setting colliders
        myObject.AddComponent<ColliderScript>();

        yield return new WaitForSeconds((float)objectSpawnSpeedInMilliseconds / 1000);

        //Recursive calls for sustainability...
        if (continueProducing) StartCoroutine(SpawnObjects());
    }

    public void SetProductionStatus(bool b)
    {
        continueProducing = false;
    }
    public bool GetProductionStatus()
    {
        return continueProducing;
    }
}
