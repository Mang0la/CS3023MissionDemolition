/****
 * Created by: Thomas Nguyen
 * Date Created: February 9, 2022
 * 
 * 
 * Last Edited by: Thomas Nguyen
 * Lasted Edited: February 9, 2022
 * Description: Camera to follow objects
 * 
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI;

    public float camZ; //the desired Z posiiton of the camera

    private void Awake()
    {
        camZ = this.transform.position.z;
    } //end Awake()

    private void FixedUpdate()
    {
        if (POI == null) return; //if no point of interest exit update

        Vector3 destination = POI.transform.position;
        destination.z = camZ;
        transform.position = destination;
    } //end FixedUpdate()

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
