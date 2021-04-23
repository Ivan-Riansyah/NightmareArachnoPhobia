using UnityEngine.UI;
using UnityEngine;

public class BossSlider : MonoBehaviour
{
    EnemyHealth enemyHealth;
    public Slider healthSlider;
    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHealth != null)
        {
            healthSlider.value = enemyHealth.currentHealth;
        }
    }
}
