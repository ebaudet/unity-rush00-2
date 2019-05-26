using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeaponInformation : MonoBehaviour
{
    public enum typeInfo
    {
        weapon_name,
        weapon_single
    }
    public typeInfo info;
    public player _player;
    protected Text text;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        _player = player.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (info == typeInfo.weapon_name)
        {
            if (null == _player.weapon)
                text.text = "No Weapon";
            else
                text.text = _player.weapon.weapon_name;
        }
        else if (info == typeInfo.weapon_single)
        {
            if (null == _player.weapon)
                text.text = "-";
            else
            {
                if (_player.weapon.inf_ammo)
                    text.text = "Inf Single";
                else
                    text.text = _player.weapon.ammo.ToString() + " Single";
            }
        }
    }
}
