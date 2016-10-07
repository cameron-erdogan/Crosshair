using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class DisplayCrosshairHoveredObject : MonoBehaviour {

	Text textDisplay;

	void OnEnable(){
		Crosshair.OnHover += hoveringOn;
	}

	void OnDisable(){
		Crosshair.OnHover -= hoveringOn;
	}

	void hoveringOn(Collider coll){
		if (coll == null) {
			textDisplay.text = "Hovering on: nothing";
		} else {
			textDisplay.text = "Hovering on: " + coll.name;
		}
	}

	// Use this for initialization
	void Start () {
		textDisplay = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
