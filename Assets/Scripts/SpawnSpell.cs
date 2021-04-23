using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpell : MonoBehaviour
{
    public Camera cam;
    public float range;
    public float fireRate = 1f;
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();
    public Demo resultDemo;
    public bool flag = false;
    public GameObject greenBombUI;
    public GameObject fireBallUI;

    protected string skillWord = "";

    private Ray rayMouse;
    private Quaternion rotation;
    private Vector3 pos;
    private Vector3 direction;
    private GameObject effectToSpawn;
    private float nextTimeToFire = 0f;
    private float skillDura = 0f;

    Animator anim;
    AudioSource spellAudio;
    GameObject player;
    PlayerHealth playerHealth;

    void Start()
    {
        effectToSpawn = vfx[0];
        anim = GetComponent<Animator>();
        spellAudio = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        skillWord = resultDemo.resultSkill;
        
        if (skillWord != null && flag)
        {
            switch (skillWord)
            {
                case "New-X":
                    effectToSpawn = vfx[1];
                    skillDura = 15f;
                    flag = false;
                    greenBombUI.SetActive(true);
                    Debug.Log("ini masuk new x");
                    break;

                case "line":
                    effectToSpawn = vfx[2];
                    skillDura = 15f;
                    flag = false;
                    fireBallUI.SetActive(true);
                    Debug.Log("ini masuk line");
                    break;

                default:
                    effectToSpawn = vfx[0];
                    break;
            }
        }

        skillDura -= 1 * Time.deltaTime;

        if (skillDura <= 0)
        {
            effectToSpawn = vfx[0];
            greenBombUI.SetActive(false);
            fireBallUI.SetActive(false);
        }

        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire && playerHealth.currentHealth > 0)
        {
            anim.Play("castSpell");
            anim.SetTrigger("casted");
            nextTimeToFire = Time.time + 1f / fireRate;  
            spawnVfx();
        }        
    }

    void spawnVfx()
    {
        RaycastHit hit;
        GameObject vfx;
        spellAudio.Play();

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            RotateToDirection(gameObject, hit.point);
            vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);
            vfx.transform.localRotation = rotation;
        }

        else
        {
            return;
        }
    }

    void RotateToDirection(GameObject obj, Vector3 destination)
    {
        direction = destination - obj.transform.position;
        rotation = Quaternion.LookRotation(direction);
    }

}
