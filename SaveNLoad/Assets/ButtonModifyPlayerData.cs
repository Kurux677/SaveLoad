using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonModifyPlayerData : MonoBehaviour {

    // Use this for initialization
    public void IncreaseAttack()
    {
        GameController.control.AddAttack();
    }

    // Update is called once per frame
    public void IncreaseDefense()
    {
        GameController.control.AddDefense();
    }

    public void IncreaseHealth()
    {
        GameController.control.AddHealth();
    }

    public void IncreaseWeaponAttack()
    {
        GameController.control.AddAttackToWeapon();
    }

    public void IncreaseNumberOfWeapon()
    {
        GameController.control.AddWeapon();
    }

    public void NextWeapon()
    {
        GameController.control.NextWeapon();
    }

    public void PreviousWeapon()
    {
        GameController.control.PreviousWeapon();
    }
}
