/****
 * Created by: Thomas Nguyen
 * Date Created: February 14, 2022
 * 
 * 
 * Last Edited by: Thomas Nguyen
 * Lasted Edited: February 14, 2022
 * Description: Generate multiple clouds
 * 
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCrafter : MonoBehaviour
{
    public int numberOfClouds = 40;
    public GameObject cloudPrefab;
    public Vector3 cloudPositionMinimum = new Vector3(-50, -5, 10);
    public Vector3 cloudPositionMax = new Vector3(150, 100, 10);
    public float CloudScaleMin = 1;
    public float CloudScaleMax = 3;
    public float CloudSpeedMultiplier = 0.5f;

    private GameObject[] cloudInstances;

    private void Awake()
    {
        cloudInstances = new GameObject[numberOfClouds];
        GameObject anchor = GameObject.Find("CloudAnchor");

        GameObject cloud;

        for(int i = 0; i < numberOfClouds; i++)
        {
            cloud = Instantiate<GameObject>(cloudPrefab);

            //position cloud
            Vector3 cPos = Vector3.zero;
            cPos.x = Random.Range(cloudPositionMinimum.x, cloudPositionMax.x);
            cPos.y = Random.Range(cloudPositionMinimum.y, cloudPositionMax.y);

            //scale clouds
            float scaleU = Random.value;
            float scaleVal = Mathf.Lerp(CloudScaleMin, CloudScaleMax, scaleU);

            cPos.y = Mathf.Lerp(cloudPositionMinimum.y, cPos.y, scaleU); //smaller clouds with smaller scale closer to the ground



        }


    } //end Awake()




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
