using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class GazableButton : GazableObj {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void setupcolor(Color buttonColor){
		GetComponent<Image>().color = buttonColor;
	}
	public override void OnPress(RaycastHit hitInfo){
		base.OnPress(hitInfo);
		setupcolor(Color.green);
	}
}
