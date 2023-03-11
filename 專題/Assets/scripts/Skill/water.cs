using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int Damage;
    public GameObject effect;
    void Start()
    {
        
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 0.5f);
    }

    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.tag==("Enemy"))
        {
            Debug.Log("hit");

            Destroy(gameObject);
            Instantiate(effect,transform.position,transform.rotation);
        }
    }
}
