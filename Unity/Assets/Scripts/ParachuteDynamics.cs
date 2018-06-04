using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParachuteDynamics : MonoBehaviour {

    /*
     * THIS SCRIPT CONTAINS THE BEHAVIOURS OF THE PARACHUTE AND BACKGROUND
     */

    public GameObject player;
    public GameObject background;

    /*
     * THIS VARIABLES DEPEND UPON SCREEN RESULOTION AND SHOULD BE MODIFIED
     * WHEN SETTING THIS PROJECT FOR MULTI DEVICES
     */
    private Vector3 playerInitialPosition = new Vector3(0, 3.12F, 0);
    private float fallSpeedperFrame = 0.03f;
    private float backgroundOffset = 0; // To prevent background from disappearing


	// Use this for initialization
	void Start () {
        //Setting initial parameters
        player.transform.position = playerInitialPosition;

    }
	
	// Update is called once per frame
	void Update () {
        if (background.transform.position.y > backgroundOffset) { //Move player
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - fallSpeedperFrame, player.transform.position.z); //Move downward
        }else { //Move background
            background.transform.position = new Vector3(background.transform.position.x, background.transform.position.y + fallSpeedperFrame, background.transform.position.z); //Move upward
        }


	}

}
