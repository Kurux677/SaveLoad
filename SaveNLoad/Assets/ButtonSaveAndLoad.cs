using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSaveAndLoad : MonoBehaviour {

	// Use this for initialization
	public void Save() {
        GameController.control.Save();
    }

    // Update is called once per frame
    public void Load()
    {
        GameController.control.Load();
    }
}
