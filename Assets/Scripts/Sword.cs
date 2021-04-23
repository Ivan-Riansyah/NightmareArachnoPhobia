using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public float damage = 100f;
    public Camera cam;
    public float range = 3f;
    public float fireRate = 0.5f;
    public bool flag = false;
    public Demo resultDemo;
    public GameObject impactEffect;
    public GameObject damageUpUI;
    public GameObject rapidSlashUI;

    protected string skillWord = "";

    AudioSource swordAudio;
    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;

    private float nextTimeToFire = 0f;
    private float skillDura = 0f;

    void Awake()
    {
        swordAudio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        skillWord = resultDemo.resultSkill;

        if (skillWord != null && flag)
        {
            switch (skillWord)
            {
                case "new-z":
                    damage = 200f;
                    skillDura = 15f;
                    flag = false;
                    damageUpUI.SetActive(true);
                    Debug.Log("ini masuk new-z");
                    break;

                case "new-v":
                    fireRate = 1f;
                    skillDura = 15f;
                    flag = false;
                    rapidSlashUI.SetActive(true);
                    Debug.Log("ini masuk new-v");
                    break;

                default:
                    damage = 100f;
                    fireRate = 0.5f;
                    break;
            }
        }

        skillDura -= 1 * Time.deltaTime;
        if (skillDura <= 0)
        {
            damage = 100f;
            fireRate = 0.5f;
            damageUpUI.SetActive(false);
            rapidSlashUI.SetActive(false);
        }

        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire && playerHealth.currentHealth > 0)
        {
            anim.Play("swordSlash");
            anim.SetTrigger("slashed");
            nextTimeToFire = Time.time + 1f / fireRate;
            Slashing();
        }
    }

    void Slashing()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        swordAudio.Play();
        if(Physics.Raycast(ray, out hit, range))
        {
            Debug.Log(hit.transform.name);
            EnemyHealth enemyhealth = hit.transform.GetComponent<EnemyHealth>();
            if (enemyhealth != null)
            {
                StartCoroutine(ShowImpact(hit, enemyhealth));
            }
        }
    }

    IEnumerator ShowImpact(RaycastHit hit, EnemyHealth enemyhealth)
    {
        yield return new WaitForSeconds(1);
        enemyhealth.TakeDamage(damage);
        GameObject impGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impGO, 0.5f);
    }
}
