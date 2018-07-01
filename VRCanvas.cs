using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCanvas : MonoBehaviour {
	private GazableButton ActiveCurrentButton;
	public Color unselectedColor = Color.white;
	public Color selectedColor = Color.green;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void setactiveButton(GazableButton activeButton){
		if (ActiveCurrentButton != null){
			ActiveCurrentButton.setupcolor(unselectedColor);
		}
		if (activeButton != null && ActiveCurrentButton != activeButton){
			ActiveCurrentButton = activeButton;
			ActiveCurrentButton.setupcolor(selectedColor);
		}
		else{
			Debug.Log("Reseting ...");
			ActiveCurrentButton = null;
		}
		
	}
}
