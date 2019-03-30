using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Weapon : MonoBehaviour {

    public int ammo;
    public int range;
    public GameObject munition;
    public string weapon_number;
    public string weapon_name;
	// Use this for initialization
	void Start () {
        //string numbersOnly = Regex.Replace(weapon_tmp, "[^0-9]", "");
        weapon_name = GetComponent<SpriteRenderer>().sprite.name;
        weapon_number = Regex.Replace(GetComponent<SpriteRenderer>().sprite.name, "[^0-9]", "");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
