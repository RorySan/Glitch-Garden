using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject explosionVFXPrefab;

    public void DealDamage (float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            var explosion = Instantiate(explosionVFXPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 1f);
            Destroy(gameObject);
           
        }
      
    }    
}
