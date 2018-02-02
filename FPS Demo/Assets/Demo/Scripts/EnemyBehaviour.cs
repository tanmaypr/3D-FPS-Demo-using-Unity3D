using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    [SerializeField]
    private float speed = 1.0f;
    [SerializeField]
    private float health = 100f;
    [SerializeField]
    private Transform player;
    public float targetDist;
    public float enemyLookDist=10f;
    Animator anim;
    private Quaternion enemyDefaultRotation;
    private Player _player; //reference variable for player script
    [SerializeField]
    private float fireRate = 0.25f;
    private float canFire = 0f;
    [SerializeField]
    private AudioClip enemyShootSound;
    [SerializeField]
    private GameObject enemyMuzzle;
   
	// Use this for initialization
	void Start () {
        _player = GameObject.Find("Player").GetComponent<Player>();
        anim = GetComponent<Animator>();
        enemyDefaultRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.zero * speed * Time.deltaTime);
        targetDist = Vector3.Distance(player.position, transform.position);
        if (targetDist < enemyLookDist)
        {
            
            
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(player.transform.position-transform.position),Time.deltaTime);
            //ShootPlayer();
            enemyMuzzle.SetActive(true);
            anim.SetBool("Run", true);
            anim.SetBool("Idle", false);
            ShootPlayer2();
            
        }
        else if (targetDist> enemyLookDist)
        {
            //transform.rotation = enemyDefaultRotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, enemyDefaultRotation, Time.deltaTime);
            enemyMuzzle.SetActive(false);
            anim.SetBool("Run", false);
            anim.SetBool("Idle", true);
        }
        if (transform.position.z >= 11)
        {
            //transform.rotation = Quaternion.Euler(0,180f,0);
           // Quaternion newRotation = Quaternion.LookRotation(new Vector3(90f, 0, 0));
            //transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime);

        }

        else if (transform.position.z<=4)
        {
            //transform.rotation = Quaternion.Euler(0,0,0);
            //Quaternion newRotation = Quaternion.LookRotation(new Vector3(0, 0, 0));
            //transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime);
            
        }

        if (health<=0)
        {
            Destroy(this.gameObject);
        }

       
	}

    public void ShootPlayer2()
    {
        RaycastHit hitInfo;
        Vector3 rayDirection = player.transform.position - transform.position;
        Debug.DrawRay(transform.position, rayDirection*10);
        if (Physics.Raycast(transform.position,rayDirection, out hitInfo,10))
        {
            if (hitInfo.transform.name=="Player")
            {
                
                Debug.Log("Player Detected");
                if (Time.time>canFire)
                {
                    AudioSource.PlayClipAtPoint(enemyShootSound, transform.position);
                    _player.PlayerDamage();
                    canFire = Time.time + fireRate;
                }
                
                
            }
        }
    }

    public void ShootPlayer()
    {
       
        Ray ray = new Ray(transform.position, -Vector3.forward * 10);
        Debug.DrawRay(transform.position, -Vector3.forward * 10);
       // Quaternion newPlayerRotation = player.transform.rotation;
        //newPlayerRotation = Quaternion.Euler(0, 0, 0);
        //transform.rotation = Quaternion.Slerp(newPlayerRotation,transform.rotation, Time.deltaTime);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.transform.name=="Player")
            {
                Debug.Log("Player found..shooting player");
                
            }
        }

    }

    public void DamageEnemy()
    {
        health -= 20;
    }
}
