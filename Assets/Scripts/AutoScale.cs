using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScale : MonoBehaviour {

	private Vector3 _addScale;
	// Use this for initialization
	void Start () {
		_addScale = new Vector3(0.3f, 0.3f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale += _addScale * Time.deltaTime;
		if (transform.localScale.x > 1.2f)
			transform.localScale = new Vector3(0.2f, 0.2f, 1);
	}
}
