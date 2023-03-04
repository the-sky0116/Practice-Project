using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    public GameObject uiBtn;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            uiBtn.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            uiBtn.SetActive(false);
        }
        
    }


}
