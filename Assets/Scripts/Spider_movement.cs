using UnityEngine.AI;
using UnityEngine;

public class Spider_movement : MonoBehaviour
{
    Transform player;
    NavMeshAgent nav;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;

    void Start()
    {
        player = GameObject.FindWithTag ("Player").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent<NavMeshAgent> ();
    }

    void Update()
    {
        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            nav.SetDestination(player.position);
        }
        
        else
        {
            nav.enabled = false;
        }
    }
}
