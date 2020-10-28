using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon : MonoBehaviour
{
    public int weaponID;
    public GameObject weaponObject;
    public string weaponName;
    public float damage;
    public float fireRate;
    public GameObject bulletSpawn;

    public enum PlayerClass
    {
        Soldier, Trapper
    }

    public PlayerClass playerClass;
}
