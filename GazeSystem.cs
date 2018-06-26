using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeSystem : MonoBehaviour {

    public GameObject reticle;

    public Color inactivatedReticle = Color.gray;

    public Color activatedReticle = Color.green;

    private GazableObj currentGazeObj;
    private GazableObj currentSelectedObj;

    private RaycastHit lastHit;

	// Use this for initialization
	void Start () {
        SetReticleColor(inactivatedReticle);
	}
	
	// Update is called once per frame
	void Update () {

        ProcessGaze();
        CheckForInput(lastHit);
        
		
	}
    public void ProcessGaze() {

        Ray raycastRay = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;
        Debug.DrawRay(raycastRay.origin, raycastRay.direction * 100);

        if (Physics.Raycast(raycastRay, out hitInfo))
        {
            // Do something to the object

            //Check if the object is interactable 

            //Get the gameobject from the hitInfo
            GameObject hitObj = hitInfo.collider.gameObject;

            //Get the Gazableobject from the hit object
            GazableObj gazeObj = hitObj.GetComponent<GazableObj>();

            // Object has a Gazable component
            if (gazeObj != null)
            {
                if (gazeObj != currentGazeObj)
                {
                    ClearCurrentObj();
                    currentGazeObj = gazeObj;
                    currentGazeObj.OnGazeEnter(hitInfo);
                    SetReticleColor(activatedReticle);
                }
                else {
                    currentGazeObj.OnGaze(hitInfo);
                }
               
            }
            else
            {
               ClearCurrentObj(); 
            }
            lastHit = hitInfo;
            //Check if the object is a new object (first time looking)

            //Set the reticle color

        }
        else
        {
            ClearCurrentObj();
        }
    }

    private void SetReticleColor(Color reticleColor)
    {
        // set the color of the reticle
        reticle.GetComponent<Renderer>().material.SetColor("_Color", reticleColor);
    }

    private void CheckForInput(RaycastHit hitInfo)
    {
        //check for down

        if (Input.GetMouseButtonDown(0) && currentGazeObj != null) {
            currentSelectedObj = currentGazeObj;
            currentSelectedObj.OnPress(hitInfo);
        }

        //check for hold 
        else if (Input.GetMouseButton(0) && currentSelectedObj != null)
        {
            currentSelectedObj.OnHold(hitInfo);
        }
        else if (Input.GetMouseButtonUp(0) && currentSelectedObj != null)
        {
            currentSelectedObj.OnRelease(hitInfo);
            currentSelectedObj = null;
        }
        //check for release
    }

    private void ClearCurrentObj()
    {
        if (currentGazeObj != null)
        {
            currentGazeObj.OnGazeExit();
            SetReticleColor(inactivatedReticle);
            currentGazeObj = null;
        }
    }

}
