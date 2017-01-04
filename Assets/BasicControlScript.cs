using UnityEngine;
using System.Collections;

public class BasicControlScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float hori = Input.GetAxis("Horizontal");
		float vert = Input.GetAxis("Vertical");

		transform.Translate(hori * Time.deltaTime, vert * Time.deltaTime, 0);
	}
}
