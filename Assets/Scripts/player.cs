using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text.RegularExpressions;

public class player : MonoBehaviour {

    public Camera cam;
    public GameObject Player;
    public GameObject weapon_sprite;
    private GameObject weapon;
    private string path;
    private string weapon_name;
    private string weapon_tmp;
    private float vertical;
    private float horizontal;
    private Vector3 cameraDif;
    private Vector3 direction;
    private GameObject weapon_collision;

	// Use this for initialization
	void Start () {
        //cameraDif = cam.transform.position.y - transform.position.y;
        //weapon_name = int.Parse(weapon_tmp);
        //weapon_sprite = GetComponent<SpriteRenderer>();
        //Debug.Log(we)

        //path = "Assets/Sprites/weapons/attach-to-body/" + numbersOnly + ".png";
        //Debug.Log(path);
        //weapon_sprite.GetComponent<SpriteRenderer>().sprite = AssetDatabase.LoadAssetAtPath<SpriteRenderer>("Assets/Sprites/weapons/attach-to-body/1.png", typeof(SpriteRenderer));
        //weapon_sprite.sprite = (Sprite)AssetDatabase.LoadAssetAtPath(path, typeof(Sprite));
        //AssetDatabase.ImportAsset("Assets/Sprites/weapons/attach-to-body/1.png", ImportAssetOptions.Default);
        //Application.
                   //weapon_sprite = 
	}
	
	// Update is called once per frame
	void Update () {
        if (weapon && Input.GetMouseButtonDown(1))
            drop_weapon();
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
        transform.Translate(horizontal, vertical, 0);
        if (weapon)
        {
            weapon.transform.position = new Vector3(transform.position.x - 0.2f, transform.position.y - 0.3f, 0);
        }
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction.z = transform.position.z;
	}

	private void FixedUpdate()
	{
        gameObject.GetComponentInChildren<SpriteRenderer>().transform.up = gameObject.GetComponentInChildren<SpriteRenderer>().transform.position - direction;
	}



    private void drop_weapon()
    {
        weapon.GetComponent<CircleCollider2D>().enabled = true;
        weapon.GetComponent<SpriteRenderer>().enabled = true;
        //weapon.GetComponent<Rigidbody2D>().AddForce(transform.up * 10f);
        weapon = null;

        weapon_sprite.gameObject.SetActive(false);
        weapon_sprite.GetComponent<SpriteRenderer>().sprite = null;//(Sprite)AssetDatabase.LoadAssetAtPath(path, typeof(Sprite));

    }


	private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<BoxCollider2D>().enabled = false;
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
        //Debug.Log(collision.gameObject.tag);
        if (Input.GetKeyDown(KeyCode.E) && collision.gameObject.tag == "weapon")
        {
            Debug.Log("ok");
            weapon = collision.gameObject;
            path = "Assets/Sprites/weapons/attach-to-body/" + weapon.GetComponent<Weapon>().weapon_number + ".png";
            //Debug.Log(path);

            weapon_sprite.gameObject.SetActive(true);
            weapon_sprite.GetComponent<SpriteRenderer>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath(path, typeof(Sprite));

            weapon.GetComponent<CircleCollider2D>().enabled = false;
            weapon.GetComponent<SpriteRenderer>().enabled = false;
        }
	}

	private void OnTriggerExit2D(Collider2D other)
	{
        if (!weapon)
            other.GetComponent<BoxCollider2D>().enabled = true;
	}

	//public void OnCollisionEnter2D(Collision2D collision)
	//{
	//    //Debug.Log("coucou");
	//    Debug.Log(collision.gameObject.tag);
	//    if (Input.GetKeyDown(KeyCode.E) && collision.gameObject.tag == "weapon")
	//    {
	//        Debug.Log("ok");
	//        weapon = collision.gameObject;
	//        path = "Assets/Sprites/weapons/attach-to-body/" + weapon.GetComponent<Weapon>().weapon_number + ".png";
	//        Debug.Log(path);
	//        //weapon.GetComponent<SpriteRenderer>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath(path, typeof(Sprite));
	//        //string numbersOnly = Regex.Replace(weapon_tmp, "[^0-9]", "");
	//        weapon.GetComponent<BoxCollider2D>().enabled = false;
	//        weapon.GetComponent<SpriteRenderer>().enabled = false;
	//        weapon_sprite.gameObject.SetActive(true);
	//        weapon_sprite.GetComponent<SpriteRenderer>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath(path, typeof(Sprite));
	//    }
	//}

}
