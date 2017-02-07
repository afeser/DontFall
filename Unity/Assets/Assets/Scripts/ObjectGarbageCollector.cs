using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGarbageCollector : MonoBehaviour {


    /*
     * FOR OBJECTS WHICH HAVE NO WORK TO DO, IT IS NECESSARY TO BE KILL
     * THIS SCRIPT DESTRYOYS THEM BY TIME
     */

    public float lifeTime=-1;

    private float defaultLifeTime=10;

	void Start () {
        if (-1 == lifeTime) lifeTime = defaultLifeTime;

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
