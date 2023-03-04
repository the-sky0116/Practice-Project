using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sign : MonoBehaviour
{
    public GameObject dialogBox;
    public GameObject SignC;
    public Text dialogBoxText;
    public string signText;
    private bool isplayerInSign;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isplayerInSign)
        {
            SignC.SetActive(true);
        }
        else
        {
            SignC.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.C)&&isplayerInSign)
        {
            dialogBox.SetActive(true);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            isplayerInSign = true;
            dialogBoxText.text = signText;
            Debug.Log("in");

        }
       
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")&&GetType().ToString()== "UnityEngine.BoxCollider2D")
        {
            isplayerInSign = false;
            dialogBox.SetActive(false);
            Debug.Log("exit");
        }
    }

}
