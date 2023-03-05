using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class time : MonoBehaviour
{
    public float timer=0;
    public GameObject load;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * 1;


        if (timer > 11)
        {
            load.SetActive(false);
        }
    }

}
