/****
 * Created by: Thomas Nguyen
 * Date Created: February 19, 2022
 * 
 * 
 * Last Edited by: Thomas Nguyen
 * Lasted Edited: February 19, 2022
 * Description: The goal reacts when hit with a projectile
 * 
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    static public bool goalMet = false;

    void OnTriggerEnter(Collider other)
    {
        // When the trigger is hit by something check to see if it's a Projectile
        if (other.gameObject.tag == "Projectile")
        {
            // If so, set goalMet to true
            Goal.goalMet = true;

            // Also set the alpha of the color to higher opacity
            Material mat = GetComponent<Renderer>().material;
            Color c = mat.color;
            c.a = 1;
            mat.color = c;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
