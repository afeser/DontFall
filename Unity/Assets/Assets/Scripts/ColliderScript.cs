using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour {


    /* IT'S TO MAKE COLLISION EFFECTS AND DESTROY COLLIDED OBJECTS
     * IT'S HANDLED BY THE OBJECTS ITSELVES
     */

    void Start () {
		
	}
	
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        // Here be some collision effects will
        //...
        //..
        //.


        // Destroy the object (for just test -will be rewitten-)
        Destroy(gameObject);
    }
}
