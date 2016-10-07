using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


[RequireComponent (typeof(Text))]
public class DisplayCrosshairClickedObjects : MonoBehaviour {

	Dictionary<string, int> clicktionary = new Dictionary<string, int>();
	Text textDisplay;

	void OnEnable(){
		Crosshair.OnClick += objectClicked;
	}

	void OnDisable(){
		Crosshair.OnClick -= objectClicked;
	}

	void objectClicked(Collider coll){
		if(clicktionary.ContainsKey(coll.name)){
			clicktionary[coll.name] += 1;
		}else{
			clicktionary.Add(coll.name, 1);
		}
	}

	// Use this for initialization
	void Start () {
		textDisplay = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		updateText ();
	}

	void updateText(){
		string output = "";

		output += "Clicked on:\n"; 
		foreach (KeyValuePair<string, int> item in clicktionary) {
			output += item.Key + "     " + item.Value + "\n";
		}

		textDisplay.text = output;
	}
}
