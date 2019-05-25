using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class enemi : MonoBehaviour {

    public SpriteRenderer head;
    public SpriteRenderer body;
    public GameObject weapon;

    void OnEnable()
    {
        // player.instance.OnGunShooted += ListenBullet;
    }

    void OnDisable()
    {
        // player.instance.OnGunShooted -= ListenBullet;
    }

    void ListenBullet(Vector3 pos, float dist)
    {
        
    }

	// Use this for initialization
    void Start ()
    {
        string path = "Assets/Sprites/characters/body/" + Random.Range(1, 4).ToString() + ".png";
        Debug.Log("body = " + path);
        body.sprite = (Sprite)AssetDatabase.LoadAssetAtPath(path, typeof(Sprite));
        path = "Assets/Sprites/characters/head/" + Random.Range(1, 13).ToString() + ".png";
        Debug.Log("head = " + path);
        head.sprite = (Sprite)AssetDatabase.LoadAssetAtPath(path, typeof(Sprite));
        //string path = "Assets/Sprites/weapons/attach-to-body/" + weapon.GetComponent<Weapon>().weapon_number + ".png";
        ////Debug.Log(path);

        //weapon_sprite.gameObject.SetActive(true);
        //weapon_sprite.GetComponent<SpriteRenderer>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath(path, typeof(Sprite));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
