/****
 * Created by: Thomas Nguyen
 * Date Created: February 16, 2022
 * 
 * 
 * Last Edited by: Thomas Nguyen
 * Lasted Edited: February 16, 2022
 * Description: Put rigidbody to sleep for 1 frame
 * 
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class RigidbodySleep : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null) rb.Sleep();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
