/****
 * Created by: Thomas Nguyen
 * Date Created: February 9, 2022
 * 
 * 
 * Last Edited by: Thomas Nguyen
 * Lasted Edited: February 16, 2022
 * Description: Camera to follow objects
 * 
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI; //the static point of interest

    [Header("Set in Inspector")]
    public float easing = 0.05f; //easing the camera by ~5%
    public Vector2 minXY = Vector2.zero;

    public float camZ; //the desired Z posiiton of the camera

    private void Awake()
    {
        camZ = this.transform.position.z;
    } //end Awake()

    private void FixedUpdate()
    {
        //if (POI == null) return; //if no point of interest exit update

        //Vector3 destination = POI.transform.position; //get the position of the POI

        Vector3 destination; //destination of POI
        if (POI == null)
        {
            destination = Vector3.zero;
        }
        else
        {
            destination = POI.transform.position;
            if (POI.tag == "Projectile")
            {
                if (POI.GetComponent<Rigidbody>().IsSleeping())
                {
                    POI = null;
                } //end if (POI.GetComponent<Rigidbody>().IsSleeping())

            } //end if (POI.tag == "Projectile")

        } //end if (POI == null)




        destination.x = Mathf.Max(minXY.x, destination.x); //finds the max value between the min x of vector 2 and the destination x
        destination.y = Mathf.Max(minXY.y, destination.y); //finds the max value between the min y of vector 2 and the destination y

        destination = Vector3.Lerp(transform.position, destination, easing); //interpolates from current camera position towards destination

        destination.z = camZ; //resets the z of the destination to the camera z
        transform.position = destination; //sets the position of the camera to the destination

        Camera.main.orthographicSize = destination.y + 10;

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
