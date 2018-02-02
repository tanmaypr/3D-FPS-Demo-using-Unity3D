using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private CharacterController controller;
    [SerializeField]
    private float speed = 5.0f;
    private float gravity = 9.81f;
    [SerializeField]
    private GameObject weapon;
    [SerializeField]
    private bool isWeaponEnabled = false;
    [SerializeField]
    private int currentAmmo;
    private int maxAmmo = 50;
    [SerializeField]
    private GameObject muzzle;
    private bool isReloading;
    [SerializeField]
    private GameObject hitMarkerPrefab;
    [SerializeField]
    private int maxHealth = 100;
    [SerializeField]
    private int currentHealth;
    [SerializeField]
    private GameObject player; //gameobject to disable enable player
    [SerializeField]
    private float fireRate=0.25f;
    private float canFire = 0f;
    [SerializeField]
    private AudioClip fireSound;
    [SerializeField]
    private AudioClip reloadSound;
   
    UIManager uiManager;
	// Use this for initialization
	void Start () {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        weapon.SetActive(false);
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        Movement();
        if (Input.GetMouseButton(0) && isWeaponEnabled == true && currentAmmo!=0)
        {
            Shoot();
            
        }

        else
        {

            muzzle.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.R) && isReloading==false)
        {
            isReloading = true;
            StartCoroutine(ReloadRoutine());
            
        }
        if (currentHealth<=0)
        {
            //Destroy(this.gameObject);
            player.SetActive(false);
            Debug.Log("Game Over!!");
        }
	}

    void Shoot()
    {
        if (Time.time>canFire)
        {
            currentAmmo--;
            muzzle.SetActive(true);
            AudioSource.PlayClipAtPoint(fireSound, transform.position);
            Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hitInfo;
            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                Debug.Log("Hit: " + hitInfo.transform.name);
                Instantiate(hitMarkerPrefab, hitInfo.point, Quaternion.identity);
                EnemyBehaviour enemy = hitInfo.transform.GetComponent<EnemyBehaviour>();
                if (enemy != null)
                {
                    enemy.DamageEnemy();
                    
                }
            }

            uiManager.UpdateAmmoCount(currentAmmo);
            canFire = Time.time + fireRate;
        }
    }

    void Movement()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 velocity = moveDirection * speed;
        velocity.y -= gravity;
        velocity = transform.transform.TransformDirection(velocity);
        controller.Move(velocity * Time.deltaTime);
    }

    public void EnableWeapon()
    {
        weapon.SetActive(true);
        isWeaponEnabled = true;
        currentAmmo = maxAmmo;
    }

    IEnumerator ReloadRoutine()
    {
        AudioSource.PlayClipAtPoint(reloadSound, transform.position);
        yield return new WaitForSeconds(2f);
        currentAmmo = maxAmmo;
        uiManager.UpdateAmmoCount(currentAmmo);
        isReloading = false;
    }

    public void PlayerDamage()
    {
        
        currentHealth -= 1;
        uiManager.UpdateHealth(currentHealth);
    }
}
