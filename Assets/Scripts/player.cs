using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text.RegularExpressions;

public class player : MonoBehaviour {

    public static player instance {get; private set;}
   
    public delegate void GunShoot(Vector3 pos, float dist);
    public event GunShoot OnGunShooted;

    public GameObject   weapon_sprite;
    public Weapon       weapon = null;
    public float        speed;
    public bool         isAlive = true;
    
    private Camera      _cam;
    private Vector3     _direction;
    private Collider2D  _take = null;
    private Quaternion  _playeRrot;
    private Quaternion  _bulletRotation;
    private Rigidbody2D _rigidBody;
    private Animator _legsAnim;
    private bool _isWalking;
    private int _throwingDir;


    private void Awake()
    {
        instance = this;
    }
	
	private void Start ()
    {
        _cam = Camera.main;
        _rigidBody = GetComponent<Rigidbody2D>();
        _legsAnim = GetComponentInChildren<Animator>();
        _throwingDir = 1;
	}

    // Key Getters
    private bool getKeyUp()
    {
        return (Input.GetKey(KeyCode.W) || Input.GetKey("up"));
    }

    private bool getKeyDown()
    {
        return (Input.GetKey(KeyCode.S) || Input.GetKey("down"));
    }

    private bool getKeyRight()
    {
        return (Input.GetKey(KeyCode.D) || Input.GetKey("right"));
    }
    
    private bool getKeyLeft()
    {
        return (Input.GetKey(KeyCode.A) || Input.GetKey("left"));
    }
	
	// Update is called once per frame
	private void Update ()
    {
        if (Time.timeScale == 1 && weapon && Input.GetMouseButtonDown(1))
            drop_weapon();
        else if (Time.timeScale == 1 && weapon && Input.GetMouseButtonDown(0))
        {
            weapon.fire(transform.position, transform.localRotation);
            Debug.Log("Raised event: OnGunShooted");
            if (OnGunShooted != null)
                OnGunShooted(transform.position, weapon.sound_propagation);
        }
        
        float vertical = 0;
        float horizontal = 0;
        if (getKeyDown())
            vertical += -0.2f;
        if (getKeyUp())
            vertical += 0.2f;
        if (getKeyLeft())
            horizontal += -0.2f;
        if (getKeyRight())
            horizontal += 0.2f;
        _rigidBody.velocity = new Vector2(speed * horizontal, speed * vertical);
        if (weapon)
            weapon.transform.position = new Vector3(transform.position.x - 0.2f, transform.position.y - 0.3f, 0);

        if (_take != null)
            take_weapon();
                
        if (_rigidBody.velocity != Vector2.zero)
        { 
            if (_isWalking != true)
                _legsAnim.SetTrigger("isWalking");
            _isWalking = true;
        }
        else
            _isWalking = false;
        _legsAnim.SetBool("walk", _isWalking);

	}

	private void FixedUpdate()
	{
        // Change direction of player to the mouse pointer
        //SpriteRenderer currentSprite = gameObject.GetComponentInChildren<SpriteRenderer>();
        _direction = _cam.ScreenToWorldPoint(Input.mousePosition);
        _direction.z = transform.position.z;
        float angle = Mathf.Atan2(_direction.y - transform.position.y, _direction.x - transform.position.x) * Mathf.Rad2Deg;
        _bulletRotation = Quaternion.Euler(0, 0, transform.rotation.z + angle);
        angle += 90;
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z + angle);
        // put camera on player position
        _cam.transform.position = new Vector3(transform.localPosition.x, transform.localPosition.y + 0.5f, -10);

	}

    private void drop_weapon()
    {
        // weapon.transform.SetParent(null);
        weapon.GetComponent<CircleCollider2D>().enabled = true;
        weapon.GetComponent<SpriteRenderer>().enabled = true;
        weapon.GetComponent<Weapon>().ThrowWeapon(_throwingDir);
        weapon = null;

        weapon_sprite.gameObject.SetActive(false);
        weapon_sprite.GetComponent<SpriteRenderer>().sprite = null;//(Sprite)AssetDatabase.LoadAssetAtPath(path, typeof(Sprite));

    }

    void take_weapon()
    {
        if (weapon == null
            && (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
            && _take.gameObject.tag == "weapon")
        {
            // Debug.Log("weapon picked up");
            weapon = _take.GetComponent<Weapon>();
            string path = "Assets/Sprites/weapons/attach-to-body/" + weapon.GetComponent<Weapon>().weapon_number + ".png";
            //Debug.Log(path);

            weapon_sprite.gameObject.SetActive(true);
            weapon_sprite.GetComponent<SpriteRenderer>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath(path, typeof(Sprite));

            // weapon.transform.SetParent(transform, false);
            weapon.GetComponent<CircleCollider2D>().enabled = false;
            weapon.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "weapon" && collision.GetComponent<BoxCollider2D>())
        {
            collision.GetComponent<BoxCollider2D>().enabled = false;
        }
        _take = collision;
        if (collision.tag == "wall")
            _throwingDir = -1;
	}

    private void OnTriggerExit2D(Collider2D other)
	{
        if (!weapon && other.GetComponent<BoxCollider2D>())
            other.GetComponent<BoxCollider2D>().enabled = true;
        if (other.tag == "bullet")
            other.GetComponent<BoxCollider2D>().isTrigger = false;
        _take = null;
        if (other.tag == "wall")
            _throwingDir = 1;
	}
}
