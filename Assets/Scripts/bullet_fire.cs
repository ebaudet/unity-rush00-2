using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_fire : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("update = " + GetComponent<BoxCollider2D>().enabled);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.tag == "wall" || collision.gameObject.tag == "enemi")
        {
            Debug.Log("Destroy bullet");
            Destroy(gameObject, 0);
            if (collision.gameObject.tag == "enemi")
                Destroy(collision.gameObject, 0.5f);
        }
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.tag == "wall" || collision.gameObject.tag == "enemi")
        {
            Debug.Log("Destroy bullet");
            Destroy(gameObject, 0);
            if (collision.gameObject.tag == "enemi")
                Destroy(collision.gameObject.GetComponentInParent<GameObject>(), 0.5f);
        }
	}
}
