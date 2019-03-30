using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Weapon : MonoBehaviour {

    public int ammo;
    public int range;
    public float fire_rate;
    public GameObject munition;
    public string weapon_number;
    public string weapon_name;
    private bool player;

    private float time;

	// Use this for initialization
	void Start ()
    {
        player = false;
        time = 0;
        //string numbersOnly = Regex.Replace(weapon_tmp, "[^0-9]", "");
        weapon_name = GetComponent<SpriteRenderer>().sprite.name;
        weapon_number = Regex.Replace(GetComponent<SpriteRenderer>().sprite.name, "[^0-9]", "");
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
	}

    public void fire()
    {
        if (time >= fire_rate)
        {
            time = 0;
        }
    }

	//private void OnTriggerEnter2D(Collider2D collision)
	//{
 //       if (collision.tag == "player")
 //           GetComponent<BoxCollider2D>().enabled = false;
	//}

	//private void OnTriggerStay2D(Collider2D collision)
	//{
 //       player = false;
 //       if (collision.tag == "player")
 //           player = true;
	//}
	//private void OnCollisionStay2D(Collision2D collision)
	//{
	//    Debug.Log("yo");
	//}
}
