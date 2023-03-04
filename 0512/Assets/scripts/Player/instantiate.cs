using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiate : MonoBehaviour
{
    public GameObject fireBall;
    public GameObject firePos;
    void Start()
    {
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(50, 0), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown((KeyCode.Q)))
        {
            Instantiate(fireBall,firePos.transform.position, Quaternion.identity);
        }
        
    }
}
