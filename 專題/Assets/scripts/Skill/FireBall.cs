using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag==("Enemy"))
        {
            Destroy(gameObject);
            Instantiate(effect, transform.position, transform.rotation);
        }
    }
   
}
