using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class enemi : MonoBehaviour {

    private GameObject head;
    private GameObject weapon;

    void OnEnable()
    {
        player.instance.OnGunShooted += ListenBullet;
    }

    void OnDisable()
    {
        player.instance.OnGunShooted -= ListenBullet;
    }

    void ListenBullet(Vector2 pos, float dist)
    {
        
    }

	// Use this for initialization
    void Start ()
    {
        weapon = transform.Find("weapon").gameObject;
        head = transform.Find("head").gameObject;
        string path = "Assets/Sprites/characters/body/" + Random.Range(1, 4).ToString() + ".png";
        Debug.Log("body = " + path);
        gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath(path, typeof(Sprite));
        path = "Assets/Sprites/characters/head/" + Random.Range(1, 13).ToString() + ".png";
        Debug.Log("head = " + path);
        head.GetComponent<SpriteRenderer>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath(path, typeof(Sprite));
        //string path = "Assets/Sprites/weapons/attach-to-body/" + weapon.GetComponent<Weapon>().weapon_number + ".png";
        ////Debug.Log(path);

        //weapon_sprite.gameObject.SetActive(true);
        //weapon_sprite.GetComponent<SpriteRenderer>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath(path, typeof(Sprite));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
