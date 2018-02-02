using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Weapon : MonoBehaviour {
    UIManager uiManager;
    Player player;
	// Use this for initialization
	void Start () {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log(other.name);
            uiManager.WeaponPickupTextOn();
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.EnableWeapon();
                uiManager.EnableCorsshair();
                Destroy(this.gameObject);
                uiManager.WeaponPickupTextOff();
                uiManager.SetAmmoCount();
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            uiManager.WeaponPickupTextOff();
        }
    }
}
