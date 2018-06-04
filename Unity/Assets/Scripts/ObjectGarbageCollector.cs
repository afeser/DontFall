using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGarbageCollector : MonoBehaviour {


    /*
     * FOR OBJECTS WHICH HAVE NO WORK TO DO, IT IS NECESSARY TO BE KILL
     * THIS SCRIPT DESTRYOYS THEM BY TIME
     */

    public float lifeTime=20;

    

	void Start () {
       StartCoroutine(DestroyTimer());
	}

	void Update () {
		
	}

    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(lifeTime);

        // Destroy the object
        Destroy(gameObject);

    }
}
