using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DOOR : MonoBehaviour
{
    public GameObject leaveC;
    bool isInsideDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C)&&isInsideDoor)
        {
            Debug.Log("go");
            SceneManager.LoadScene("levelone");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            isInsideDoor = true;
            leaveC.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")&&other.GetType().ToString()=="UnityEngine.BoxCollider2D")
        {
            isInsideDoor = false;
            leaveC.SetActive(false);
        }
    }
}
