using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class explosionEffect : MonoBehaviour
{
    
    
    void Start()
    {
        Destroy(gameObject, 0.4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
