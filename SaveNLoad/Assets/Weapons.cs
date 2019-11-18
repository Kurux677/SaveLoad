using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
[Serializable]
public class Weapons {

    public int attackWeapon;
	// Use this for initialization
	public Weapons() {
        attackWeapon = 0;
	}
	
	// Update is called once per frame
	public void AddAttack() {
        attackWeapon++;		
	}
}

