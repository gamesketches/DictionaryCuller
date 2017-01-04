using UnityEngine;
using System.Collections;

public class CreateObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.A)) {
			Instantiate(Resources.Load<GameObject>("RandoPrefab"), new Vector3(Random.Range(-30, 30), Random.Range(-30, 30), 0), Quaternion.identity);
			Debug.Log("Making object");
		}
	}
}
