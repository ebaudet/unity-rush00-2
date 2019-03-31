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
    private PrefabUtility bullet;
    private string path;
    private string name;
    private float time;

	// Use this for initialization
	void Start ()
    {
        player = false;
        time = 0;
        //string numbersOnly = Regex.Replace(weapon_tmp, "[^0-9]", "");
        weapon_name = GetComponent<SpriteRenderer>().sprite.name;
        weapon_number = Regex.Replace(GetComponent<SpriteRenderer>().sprite.name, "[^0-9]", "");
        name = "bullet of " + weapon_name;

        bullet = new PrefabUtility();

        //bullet.GameObject.name = name;
        ////bullet = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/prefab/bullet.prefab", typeof(GameObject));
        //bullet.GameObject.AddComponent<SpriteRenderer>();
        //path = "Assets/Sprites/weapons/shoot/" + weapon_number + ".png";
        //bullet.GetComponent<SpriteRenderer>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath(path, typeof(Sprite));
        //bullet.AddComponent<BoxCollider2D>();
        ////bullet.GetComponent<BoxCollider2D>().size = bullet.GetComponent<SpriteRenderer>().size;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
	}

    public void fire(Vector3 pos, Quaternion rotation)
    {
        if (time >= fire_rate)
        {
            time = 0;
            //Instantiate(bullet, pos, rotation);
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
