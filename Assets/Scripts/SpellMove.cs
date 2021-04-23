using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellMove : MonoBehaviour
{
    public float speed = 20f;
    public float damage = 100f;
    public GameObject impactEffect;

    void Update()
    {
        if (speed != 0)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
        
        else
        {
            Debug.Log("no speed");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(this.gameObject.name + " hit " + collision.gameObject.name);
        speed = 0f;
        Destroy(gameObject);
        EnemyHealth enemyhealth = collision.transform.GetComponent<EnemyHealth>();
        
        if (enemyhealth != null)
        {
            enemyhealth.TakeDamage(damage);
        }
        
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
        var hitVFX = Instantiate(impactEffect, pos, rot);
        Destroy(hitVFX, 1f);
    }
}
