using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTransform : MonoBehaviour
{
    public Transform DoorEnter;
    public Transform ExitDoor;
    public Transform PlayerPosition;

    public bool isDoor;
    void Start()
    { 
        PlayerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); 
    }

    // Update is called once per frame
    void Update()
    {
         if(isDoor)
        {
            SceneManager.LoadScene("leveltwo");
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("EnterDoor");
            isDoor = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("ExitDoor");
            isDoor = false;
        }
    }
}
