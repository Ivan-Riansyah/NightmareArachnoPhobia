using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float startingHealth = 50;
    public float currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 1;
    public AudioClip deathClip;

    Animator anim;
    CapsuleCollider capsuleCollider;
    AudioSource enemyAudio;
    
    bool isDead;
    bool isSinking;

    void Awake()
    {
        anim = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        enemyAudio = GetComponent<AudioSource>();
        currentHealth = startingHealth;
    }

    void Update()
    {
        if (isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage(float amount)
    {
        if (isDead)
            return;

        enemyAudio.Play();
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        capsuleCollider.isTrigger = true;
        anim.SetTrigger("Dead");
        enemyAudio.clip = deathClip;
        enemyAudio.Play();
        TotalKill.totalKill += scoreValue;

    }

    public void StartSinking()
    {
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        Destroy(gameObject, 2f);
    }
}
