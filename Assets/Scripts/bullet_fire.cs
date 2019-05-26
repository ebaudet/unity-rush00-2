using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_fire : MonoBehaviour
{
	void Update()
	{
		Debug.Log("update = " + GetComponent<BoxCollider2D>().enabled);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		// Debug.Log("OnCollisionEnter2D");
		string colTag = collision.gameObject.tag;

		if (transform.tag == "bullet-player")
			attack(collision.gameObject, "Player", "enemi");
		else if (transform.tag == "bullet-enemy") {
			attack(collision.gameObject, "enemi", "Player");
		}
		
		if (colTag == "wall") {
			Destroy(gameObject);
		}
	}

	private void attack(GameObject g, string ownTag, string otherTag)
	{
		if (g.tag != ownTag)
		{
			Debug.Log(g.name);
			if (g.tag == otherTag) {
				if (otherTag == "Player")
					player.instance.isAlive = false;
				else
					g.GetComponent<enemi>().Die();
			}
			Destroy(gameObject);
		}
	}
}
