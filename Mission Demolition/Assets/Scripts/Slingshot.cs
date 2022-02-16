/****
 * Created by: Thomas Nguyen
 * Date Created: February 9, 2022
 * 
 * 
 * Last Edited by: Thomas Nguyen
 * Lasted Edited: February 16, 2022
 * Description: Slingshot controller
 * 
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    static private Slingshot S;

    [Header("Set in Inspector")]
    public GameObject prefabProjectile;
    public float velocityMultiplier = 8f;

    [Header("Set Dynamuically")]
    public GameObject launchPoint;
    public Vector3 launchPos;
    public GameObject projectile; //instance of the projectile
    public bool aimingMode; //is player aiming
    public Rigidbody projectileRB; //rigidbody of the projectile

    static public Vector3 Launch_Pos
    {
        get { 
            if (S == null) return Vector3.zero;
            return S.launchPos;
        }
    }

    private void Awake()
    {
        S = this;

        Transform launchPointTrans = transform.Find("LaunchPoint"); //every gameobject has a transform component
        launchPoint = launchPointTrans.gameObject; //looks for another transform component with the same name because its referencing the transformation    

        launchPoint.SetActive(false); //disables the launchpoint 
        launchPos = launchPointTrans.position; //position of launch point
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!aimingMode) return; // if not aiming exit update

        //get mouse position from 2D coordinates
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 mouseDelta = mousePos3D - launchPos;

        //limit the mouseDelta to the slingshot collider radius
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;

        if (mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize(); //sets tyhe vector to the same direction but with a length of 1
            mouseDelta *= maxMagnitude;
        } //end if (mouseDelta > maxMagnitude)

        //Move projectile to new position
        Vector3 projectilePos = launchPos + mouseDelta; //
        projectile.transform.position = projectilePos;

        if (Input.GetMouseButtonUp(0))
        {
            //if mouse button has been released
            aimingMode = false;
            projectileRB.isKinematic = false;
            projectileRB.velocity = -mouseDelta * velocityMultiplier;
            FollowCam.POI = projectile;
            projectile = null; //empties reference to instance projectile
        }


    } //end Update()

    private void OnMouseEnter()
    {
        launchPoint.SetActive(true); //enables the launchpoint when hovering the mouse over
        print("Slingshot: OnMouseEnter");
    }

    private void OnMouseExit()
    {
        launchPoint.SetActive(false); //disables the launchpoint 
        print("Slingshot: OnMouseExit");
    } //end OnMouseExit()

    public void OnMouseDown()
    {
        aimingMode = true; //player is aiming
        projectile = Instantiate(prefabProjectile) as GameObject; //instantiate projectile instance
        projectile.transform.position = launchPos;
        projectileRB = projectile.GetComponent<Rigidbody>();
        projectileRB.isKinematic = true;
    } //end OnMouseDown()
}
