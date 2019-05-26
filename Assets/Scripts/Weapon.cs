using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text.RegularExpressions;

public class Weapon : MonoBehaviour {

    public int ammo;
    public bool inf_ammo;
    public float fire_rate;
    public string weapon_number;
    public string weapon_name;
    public GameObject bullet;

    private string _path;
    private float _time;
    private GameObject _bulletShooted;
    private AudioClip _no_ammo;
    private bool    _canRotate = false;
    private float _sound_propagation;

	private void Start ()
    {
        _time = 0;
        _no_ammo = (AudioClip)AssetDatabase.LoadAssetAtPath("Assets/Audio/Sounds/dry_fire.wav", typeof(AudioClip));
        weapon_name = GetComponent<SpriteRenderer>().sprite.name;
        weapon_number = Regex.Replace(GetComponent<SpriteRenderer>().sprite.name, "[^0-9]", "");
        _path = "Assets/Sprites/weapons/shoot/" + weapon_number + ".png";
        _sound_propagation = gameObject.GetComponent<AudioSource>().maxDistance;
	}
	
	private void Update ()
    {
        _time += Time.deltaTime;
        if (_canRotate)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * 50 * GetComponent<Rigidbody2D>().velocity.sqrMagnitude);
            if (GetComponent<Rigidbody2D>().velocity.sqrMagnitude < 0.1)
                _canRotate = false;
        }
        
	}
    
    public float getSoundPropagation() {
        return _sound_propagation;
    }

    public void fire(Vector3 pos, Quaternion player_rot)
    {
        // Debug.Log("time = " + time);
        if (ammo == 0 && !inf_ammo)
            gameObject.GetComponent<AudioSource>().clip = _no_ammo;
        if (_time >= fire_rate)
            gameObject.GetComponent<AudioSource>().Play();
        if ((ammo > 0 || inf_ammo) && _time >= fire_rate)
        {
            _time = 0;
            if (!inf_ammo)
                ammo--;
            bullet.GetComponent<SpriteRenderer>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath(_path, typeof(Sprite));
            //Debug.Log(player_rot.eulerAngles.z);
            // player_rot = Quaternion.Euler(0, 0, transform.rotation.z + 180);
            _bulletShooted = Instantiate(bullet, pos, player_rot);
            transform.rotation = player_rot;
            Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction.z = transform.position.z;
            float angle = Mathf.Atan2(direction.y - transform.position.y, direction.x - transform.position.x) * Mathf.Rad2Deg;
            _bulletShooted.transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z + angle);          
            _bulletShooted.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector3.down * 20);
            if (inf_ammo)
                Destroy(_bulletShooted, 0.1f);
        }
    }

    public void ThrowWeapon(int throwingDir)
    {
        Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dir.z = transform.position.z;
        float angle = Mathf.Atan2(dir.y - transform.position.y, dir.x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z + angle + 90);          
        GetComponent<Rigidbody2D>().AddForce(transform.TransformDirection(Vector3.down * 5 * throwingDir), ForceMode2D.Impulse);
        _canRotate = true;
    }

    // private void OnCollisionEnter2D(Collision2D other) {
    //     if (other.transform.tag == "wall")
    //     {
    //         Debug.Log("Inverse weapon's velocity");
    //         GetComponent<Rigidbody2D>().velocity *= -1;
    //     }
    // }

}
