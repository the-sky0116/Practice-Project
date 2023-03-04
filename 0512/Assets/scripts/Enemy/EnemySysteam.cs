using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySysteam : MonoBehaviour
{
    public int Health;
    public int Damage;
    private PlayerHeal playerHeal;
    
    public void Start()
    {
        playerHeal = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHeal>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamege(int damege)
    {
        Health -= damege;
        if(Health<=0)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(playerHeal!=null)
            {
                Debug.Log("Hit");
            }
        }
        if(other.tag==("FireBall"))
        {
            TakeDamege(Damage);
        }
        if(other.tag==("Water"))
        {
            TakeDamege(Damage = 10);
        }
        if (other.tag == ("Rock"))
        {
            TakeDamege(Damage = 15);
        }

    }
}
