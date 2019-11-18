using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameController : MonoBehaviour {
    public static GameController control;

    public int attack;
    public int defense;
    public int health;
    public List<Weapons> weapons;
    public int index;


	// Use this for initialization
	void Start () {
		if(control==null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
            SetDefaultValue();
        }
        else
        {
            Destroy(gameObject);
        }
	}

    public void SetDefaultValue()
    {
        attack = 1;
        defense = 1;
        health = 1;
        weapons = new List<Weapons>();
        weapons.Add(new Weapons());
        index = 0;
    }

    public void AddAttack()
    {
        attack++;
    }
    public void AddDefense()
    {
        defense++;
    }
    public void AddHealth()
    {
        health++;
    }

    public void AddAttackToWeapon()
    {
        weapons[index].AddAttack();
    }

    public void AddWeapon()
    {
        weapons.Add(new Weapons());
        index = weapons.Count - 1;
    }

    public void NextWeapon()
    {
        if(index<weapons.Count-1)
        {
            index++;
        }
        else
        {
            index=0;
        }
    }
    public void PreviousWeapon()
    {
        if (index !=0 )
        {
            index--;
        }
        else
        {
            index = weapons.Count - 1;
        }
    }

    public void Load()
    {
        BinaryFormatter bf = new BinaryFormatter();
        if(!File.Exists(Application.persistentDataPath + "gameInfo.dat"))
        {
            throw new Exception("Game file doesn't exist");
        }
        FileStream file = File.Open(Application.persistentDataPath + "gameInfo.dat", FileMode.Open);
        PlayerData playerDataToLoad = (PlayerData)bf.Deserialize(file);
        file.Close();
        attack = playerDataToLoad.attack;
        defense = playerDataToLoad.defense;
        health = playerDataToLoad.health;
        weapons = playerDataToLoad.weapons;
        index = playerDataToLoad.indexWeapons ;
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "gameInfo.dat",FileMode.Create);
        PlayerData playerDataToSave = new PlayerData();
        playerDataToSave.attack = attack;
        playerDataToSave.defense = defense;
        playerDataToSave.health = health;
        playerDataToSave.weapons = weapons;
        playerDataToSave.indexWeapons = index;
        bf.Serialize(file, playerDataToSave);
        file.Close();
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 32;
        GUI.Label(new Rect(10, 60, 100, 80),  "Attack : " + attack, style);
        GUI.Label(new Rect(10, 110, 100, 80), "Defense : "+ defense, style);
        GUI.Label(new Rect(10, 160, 100, 80), "Health : "+ health, style);
        GUI.Label(new Rect(10, 210, 100, 80), "Weapon attack : "+ weapons[index].attackWeapon, style);
        GUI.Label(new Rect(10, 260, 100, 80), "Weapon index : "+index, style);
    }

}
[Serializable]
class PlayerData
{
    public int attack;
    public int defense;
    public int health;
    public List<Weapons> weapons;
    public int indexWeapons;
}
