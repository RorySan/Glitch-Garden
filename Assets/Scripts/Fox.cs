using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject target = collision.gameObject;

        if (target.GetComponent<Gravestone>())
        {
            GetComponent<Animator>().SetTrigger("jump Trigger");
        }
        else if (target.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(target);
        }
    }
}
