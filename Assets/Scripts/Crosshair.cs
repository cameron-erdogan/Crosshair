using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {

	//crosshair event delgate functions
	//OnMouseDown continually gets called when the mouse button is down
	//OnClick only gets called on the first mouse down frame
	public delegate void CrosshairEventDelegate(Collider target);
	public static event CrosshairEventDelegate OnHover;
	public static event CrosshairEventDelegate OnMouseDown;
	public static event CrosshairEventDelegate OnClick;

	//set these in the editor
	public Transform parentCharacter;
	public Transform renderedCrosshair;

	//pick this in editor
	public float depth = 5;

	//for hovering crossahir just above raycast surface
	private float fudgeAmount = 0.1f;


	// Use this for initialization
	void Start () {
		transform.localPosition = new Vector3 (0, 0, depth);
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (Input.GetMouseButton (0));

		RaycastHit hit;
		Vector3 direction = transform.forward;
		if (Physics.Raycast (parentCharacter.position, direction, out hit)) {
			
			renderedCrosshair.position = hit.point + hit.normal * fudgeAmount;
			renderedCrosshair.rotation = Quaternion.LookRotation (-hit.normal);

			//event stuff
			if (Input.GetMouseButton (0) == true) {
				if (Input.GetMouseButtonDown(0) == true){
					if(OnClick != null){
						OnClick(hit.collider);
					}
				}

				if (OnMouseDown != null) {
					OnMouseDown (hit.collider);
				}
			}
			else {
				if (OnHover != null) {
					OnHover (hit.collider);	
				}
			}
		
		} else {
			renderedCrosshair.localPosition = Vector3.zero;
			renderedCrosshair.localEulerAngles = Vector3.zero;

			//sort of hacky, but will tell appropriate objects "nothing is being hovered on"
			if(OnHover != null)
				OnHover(null);
		}
	}
}
