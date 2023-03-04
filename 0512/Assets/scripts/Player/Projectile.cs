using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [HideInInspector]
    public int damage;

    private void OnTriggerEnter(Collider other)
    {
        EnemyHeal d = other.GetComponent<EnemyHeal>();

        if (d != null)
            d.TakeDamage(damage);

        Destroy(this.gameObject);
    }
}
