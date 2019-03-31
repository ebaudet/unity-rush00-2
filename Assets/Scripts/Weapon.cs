using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text.RegularExpressions;

public class Weapon : MonoBehaviour {

    public int ammo;
    public bool inf_ammo;
    public int range;
    public float fire_rate;
    //public GameObject munition;
    public string weapon_number;
    public string weapon_name;
    private bool player;
    public GameObject bullet;
    private string path;
    private float time;
    //private <>
    private GameObject tmp;

	// Use this for initialization
	void Start ()
    {
        player = false;
        time = 0;
        weapon_name = GetComponent<SpriteRenderer>().sprite.name;
        weapon_number = Regex.Replace(GetComponent<SpriteRenderer>().sprite.name, "[^0-9]", "");

        //bullet = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/prefab/bullet.prefab", typeof(GameObject));

        //bullet.GameObject.AddComponent<SpriteRenderer>();
        path = "Assets/Sprites/weapons/shoot/" + weapon_number + ".png";
        //bullet.GameObject.name = "bullet of " + weapon_name;
        //bullet.AddComponent<BoxCollider2D>();
        Debug.Log(weapon_name + " collider = " + bullet.GetComponent<BoxCollider2D>().enabled);
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
	}

    public void fire(Vector3 pos, Quaternion player_rot)
    {
        if (time >= fire_rate)
        {
            time = 0;
            bullet.GetComponent<SpriteRenderer>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath(path, typeof(Sprite));
            Debug.Log(player_rot.eulerAngles.z);
            tmp = Instantiate(bullet, pos, player_rot);
            transform.rotation = player_rot;
            //tmp.GetComponent<Rigidbody2D>().AddForce(transform.up * 1000.0f);
            //transform.up = rotation.eulerAngles;
            //tmp.GetComponent<Rigidbody2D>().MoveRotation(90);
            //tmp.GetComponent<Rigidbody2D>().AddForce;
            //tmp.transform.rotation = new Quaternion (player_rot.eulerAngles.x, player_rot.eulerAngles.y, player_rot.eulerAngles.z);
            //tmp.GetComponent<Rigidbody2D>().rotation = 90;
            //Debug.Log("rot = " + player_rot.eulerAngles.z);
            //tmp.transform.rotation = player_rot;
            //tmp.transform.rotation.z += 90;

            //tmp.GetComponent<SpriteRenderer>().
            //tmp.GetComponent<Rigidbody2D>().rotation = player_rot.eulerAngles.z;
            //Debug.Log("fire : " + tmp.GetComponent<BoxCollider2D>().enabled);
            //Destroy(tmp, 2);

            //direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //direction.z = transform.position.z;
            GameObject currentSprite = tmp;
            //float angle = Mathf.Atan2(direction.y - tmp.transform.position.y, direction.x - tmp.transform.position.x) * Mathf.Rad2Deg;
            //float angle = Vector3.Angle(pos, direction);
            //angle += 90;
            //tmp.transform.rotation = Quaternion.Euler(0, 0, tmp.transform.rotation.z + angle);
            //tmp.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector3.down * 10);
            tmp.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector3.down * 10);

            //tmp.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector3.down * 10);

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
