using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class healthBar : MonoBehaviour
{
    public Text healText;
    public static int HealthCurrent;
    public int HealthMax;

    private Image HealrhBar;
    void Start()
    {
        HealrhBar = GetComponent<Image>();
        HealthCurrent = HealthMax;

    }
    void Update()
    {
        HealrhBar.fillAmount = (float)HealthCurrent / (float)HealthMax;
        healText.text = HealthCurrent.ToString() + "/" + HealthMax.ToString();
        if(HealthCurrent<=0)
        {
            healText.text = "0";
            HealthCurrent = 0;
        }    
    }

}