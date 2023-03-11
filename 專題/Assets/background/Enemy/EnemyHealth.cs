using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float hpnow;
    public float hpmax;
    public Image hpimage;  // 血條
    GameObject enemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hpimage.fillAmount = hpnow / hpmax;
        Debug.Log(hpimage.fillAmount);
    }
}
