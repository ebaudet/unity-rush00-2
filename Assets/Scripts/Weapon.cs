using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Weapon : MonoBehaviour {

    public int ammo;
    public int range;
    public GameObject munition;
    private string weapon_number;
	// Use this for initialization
	void Start () {
        //string numbersOnly = Regex.Replace(weapon_tmp, "[^0-9]", "");
        weapon_number = Regex.Replace(GetComponent<SpriteRenderer>().name, "[^0-9]", "");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
