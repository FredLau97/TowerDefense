using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ItemDatabase database;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        database = GetComponent<ItemDatabase>();

        foreach (Weapon weapon in database.weapons)
        {
            if (weapon.playerClass.ToString() == player.playerClass.ToString())
            {
                player.weapons.Add(weapon);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
