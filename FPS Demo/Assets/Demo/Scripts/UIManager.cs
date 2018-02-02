using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    [SerializeField]
    private GameObject weaponPickupText;
    [SerializeField]
    private GameObject crosshair;
    [SerializeField]
    private Text ammoCount;
    [SerializeField]
    private Text playerHealth;
   
	// Use this for initialization
	void Start () {
        weaponPickupText.SetActive(false);
        crosshair.SetActive(false);
        ClearAmmoText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void WeaponPickupTextOn()
    {
        weaponPickupText.SetActive(true);

    }

    public void WeaponPickupTextOff()
    {
        weaponPickupText.SetActive(false);
    }

    public void EnableCorsshair()
    {
        crosshair.SetActive(true);
        
    }

    public void ClearAmmoText()
    {
        ammoCount.text = "";
       
    }

    public void SetAmmoCount()
    {
        ammoCount.text = "Ammo: 50/50";
    }

    public void UpdateAmmoCount(int Currentammo)
    {
        ammoCount.text ="Ammo: " + Currentammo + "/50";
    }

    public void UpdateHealth(int Currenthealth)
    {
        playerHealth.text = "Health: " + Currenthealth + "/100";
    }
}
