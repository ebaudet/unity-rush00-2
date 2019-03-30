using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text.RegularExpressions;

public class player : MonoBehaviour {

    public GameObject Player;
    public SpriteRenderer weapon_sprite;
    private GameObject weapon;
    private string path;
    private string weapon_name;
    private string weapon_tmp;
    private float vertical;
    private float horizontal;

	// Use this for initialization
	void Start () {
        weapon_tmp = "5-Uzi";
        //weapon_name = int.Parse(weapon_tmp);
        weapon_sprite = GetComponent<SpriteRenderer>();
        Debug.Log(weapon_sprite.name);

        //path = "Assets/Sprites/weapons/attach-to-body/" + numbersOnly + ".png";
        //Debug.Log(path);
        //weapon_sprite.GetComponent<SpriteRenderer>().sprite = AssetDatabase.LoadAssetAtPath<SpriteRenderer>("Assets/Sprites/weapons/attach-to-body/1.png", typeof(SpriteRenderer));
        weapon_sprite.sprite = (Sprite)AssetDatabase.LoadAssetAtPath(path, typeof(Sprite));
        //AssetDatabase.ImportAsset("Assets/Sprites/weapons/attach-to-body/1.png", ImportAssetOptions.Default);
        //Application.
                   //weapon_sprite = 
	}
	
	// Update is called once per frame
	void Update () {
        vertical = 0;
        horizontal = 0;
        if (Input.GetKey(KeyCode.S))
            vertical += -0.2f;
        if (Input.GetKey(KeyCode.W))
            vertical += 0.2f;
        if (Input.GetKey(KeyCode.A))
            horizontal += -0.2f;
        if (Input.GetKey(KeyCode.D))
            horizontal += 0.2f;
        //transform.position = new Vector3(transform.localPosition.x + horizontal, transform.localPosition.y + vertical, 0);
        transform.Translate(horizontal, vertical, 0);
        
	}

	private void OnCollisionEnter(Collision collision)
	{
        if (collision.gameObject.tag == "weapon")
        {
            weapon = collision.gameObject;
            //weapon.GetComponent<SpriteRenderer>().sprite;
                  //string numbersOnly = Regex.Replace(weapon_tmp, "[^0-9]", "");
        }
	}
}
