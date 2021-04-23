using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float damage = 50;
    public float fireRate = 1f;
    public float range = 100f;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public GameObject damageUpUI;
    public GameObject rapidFireUI;
    public bool flag = false;
    public Demo resultDemo;

    protected string skillWord = "";
    private float nextTimeToFire = 0f;
    float skillDura = 0f;

    Animator anim;
    AudioSource gunAudio;
    GameObject player;
    PlayerHealth playerHealth;

    void Awake()
    {
        anim = GetComponent<Animator>();
        gunAudio = GetComponent<AudioSource>();
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
                case "new-s":
                    damage = 100f;
                    skillDura = 15f;
                    flag = false;
                    damageUpUI.SetActive(true);
                    Debug.Log("ini masuk new-s");
                    break;

                case "new-m":
                    fireRate = 2f;
                    skillDura = 15f;
                    flag = false;
                    rapidFireUI.SetActive(true);
                    Debug.Log("ini masuk new-m");
                    break;

                default:
                    damage = 50f;
                    fireRate = 1f;
                    break;
            }
        }

        skillDura -= 1 * Time.deltaTime;

        if (skillDura <= 0)
        {
            damage = 50f;
            fireRate = 1f;
            damageUpUI.SetActive(false);
            rapidFireUI.SetActive(false);
        }

        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire && playerHealth.currentHealth > 0)
        {
            anim.Play("shootGun");
            anim.SetTrigger("Shooted");
            nextTimeToFire = Time.time + 1f / fireRate;
            Shooting();
        }
    }

    void Shooting()
    {
        muzzleFlash.Play();
        gunAudio.Play();
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            EnemyHealth enemyhealth = hit.transform.GetComponent <EnemyHealth>();
            
            if (enemyhealth != null)
            {
                enemyhealth.TakeDamage(damage);
            }

            GameObject impGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impGO, 0.5f);
        }
    }
}
