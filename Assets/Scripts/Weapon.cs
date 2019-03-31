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
    public string weapon_number;
    public string weapon_name;
    private bool player;
    public GameObject bullet;
    private string path;
    private float time;
    private GameObject bulletShooted;

	// Use this for initialization
	void Start ()
    {
        player = false;
        time = 0;
        weapon_name = GetComponent<SpriteRenderer>().sprite.name;
        weapon_number = Regex.Replace(GetComponent<SpriteRenderer>().sprite.name, "[^0-9]", "");
        path = "Assets/Sprites/weapons/shoot/" + weapon_number + ".png";
        //Debug.Log(weapon_name + " collider = " + bullet.GetComponent<BoxCollider2D>().enabled);
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
            //Debug.Log(player_rot.eulerAngles.z);
            bulletShooted = Instantiate(bullet, pos, player_rot);
            transform.rotation = player_rot;

            Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction.z = transform.position.z;
            float angle = Mathf.Atan2(direction.y - transform.position.y, direction.x - transform.position.x) * Mathf.Rad2Deg;
            bulletShooted.transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z + angle);          
            bulletShooted.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector3.down * 10);
        }
    }

}
