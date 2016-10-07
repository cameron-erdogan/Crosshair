using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Collider))]
[RequireComponent (typeof(MeshRenderer))]
public class CrosshairColorChangeListener : MonoBehaviour {

	enum CrosshairStatus {None, Hover, Click};

	private Collider coll;
	private MeshRenderer meshRenderer;
	private CrosshairStatus crosshairStatus = CrosshairStatus.None;

	void Start(){
		coll = GetComponent<Collider> ();
		meshRenderer = GetComponent<MeshRenderer> ();
	}
		

	void OnEnable(){
		Crosshair.OnHover += hoverColorChange;
		Crosshair.OnMouseDown += clickColorChange;
	}

	void OnDisable(){
		Crosshair.OnHover -= hoverColorChange;
		Crosshair.OnMouseDown -= clickColorChange;
	}

	void hoverColorChange(Collider coll){
		
		if (coll == this.coll) {
			//means we're the one being hovered on
			if (crosshairStatus != CrosshairStatus.Hover) {
				crosshairStatus = CrosshairStatus.Hover;
				meshRenderer.material.color = Color.yellow;
			}
		} 
		else if (crosshairStatus != CrosshairStatus.None){
			//means we're not being hovered or clicked on, make sure our status is none
			resetColor();
		}
	}

	void clickColorChange(Collider coll){
		if (coll == this.coll) {
			//means we're the one being clicked on
			if (crosshairStatus != CrosshairStatus.Click) {
				crosshairStatus = CrosshairStatus.Click;
				meshRenderer.material.color = Color.red;
			}
		} else if (crosshairStatus != CrosshairStatus.None){
			resetColor ();
		}
	}

	private void resetColor(){
		//means we're not being hovered or clicked on, make sure our status is none
		crosshairStatus = CrosshairStatus.None;
		meshRenderer.material.color = Color.white;
	}
}
