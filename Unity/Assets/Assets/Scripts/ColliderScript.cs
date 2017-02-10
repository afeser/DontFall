using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour {

    // - Furkan    
    // this script will be a part of the ADAM
    // - Furkan


    /* IT'S TO MAKE COLLISION EFFECTS AND DESTROY COLLIDED OBJECTS
     * IT'S HANDLED BY THE OBJECTS ITSELVES
     */

        // these can be made public so that they can be edited inside the unity editor
    private int healthBars = 3;
    private float playerAir;
    private float playerFullness;           // not hunger, but being full

    void Start () {
        getHungry();
        airDecrease();
	}
	
	void Update () {
		
	}

    void getHungry()
    {
        //playerFullness will decrease over time
    }

    void airDecrease()
    {
        //playerAir will decrease over time
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            healthBars--;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("FoodBoost"))
        {
            //playerFullness will increase
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("AirBoost"))
        {
            //playerAir will increase
            Destroy(other.gameObject);
        }
    }
}
