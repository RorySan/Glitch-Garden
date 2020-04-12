using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{

    [Range(1, 7)][SerializeField] float projectileSpeed = 5f;
    [SerializeField] int damage = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Attacker")
        {
            collision.GetComponent<Attacker>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
