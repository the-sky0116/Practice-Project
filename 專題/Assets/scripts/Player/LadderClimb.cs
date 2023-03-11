using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderClimb : MonoBehaviour
{
    public float ClimbSpeed = 2;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag=="Player")
        {
            if(Input.GetKey(KeyCode.W))
            {
                col.GetComponent<Rigidbody2D>().gravityScale = 0;
                col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, ClimbSpeed);
            }
            else
            {
                col.GetComponent<Rigidbody2D>().gravityScale = 4;
            }
            if(Input.GetKey(KeyCode.S))
            {
                col.GetComponent<Rigidbody2D>().gravityScale = 0;
                col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -ClimbSpeed);
            }
            else
            {
                col.GetComponent<Rigidbody2D>().gravityScale = 4;
            }
            Debug.Log("HIT");
        }
    }
    
}
