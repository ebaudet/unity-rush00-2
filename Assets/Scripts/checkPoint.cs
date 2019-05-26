using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour {
	public List<Transform>	checkPoints;

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "enemi") {
			Debug.Log("OnTriggerEnter2D enemi");
			other.gameObject.GetComponent<enemi>().changePatrolPath(checkPoints);
		}
	}

	private void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "enemi") {
			other.gameObject.GetComponent<enemi>().emptyCheckPoint();
		}
	}
}
