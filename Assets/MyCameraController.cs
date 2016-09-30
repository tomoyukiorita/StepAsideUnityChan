using UnityEngine;
using System.Collections;

public class MyCameraController : MonoBehaviour {

	private float difference;

	private GameObject unitychan ;

	// Use this for initialization
	void Start () {
		unitychan = GameObject.Find("unitychan");

		difference = unitychan.transform.position.z - transform.position.z;
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (0, transform.position.y, unitychan.transform.position.z - difference);
	
	}
}
