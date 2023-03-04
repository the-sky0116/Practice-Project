using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cooldown2 : MonoBehaviour
{
    [Header("Water")]
    public Image CooldownImage2;
    public float cooldown = 1;
    public KeyCode Water2;
    public GameObject waterHitEffect;
    public GameObject waterEffect;
    public int waterCost = 10;

    public MagicBar MpBar;
    bool canUseSkill=false;
    public Transform firePos;
    bool isCooldown=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Water();
    }
    void Water()
    {
        if (Input.GetKeyDown(KeyCode.J) && isCooldown == false && MpBar.MagicCurrent>=10)
        {
            Debug.Log("J");
            canUseSkill = true;
            isCooldown = true;
            CooldownImage2.fillAmount = 1;
            MpBar.MagicCurrent -= waterCost;
            Debug.Log("water");
            Instantiate(waterEffect, firePos.position, firePos.rotation);
            if (MpBar.MagicCurrent <= 0)
            {
                MpBar.MagicCurrent = 0;
            }
            if (MpBar.MagicCurrent > 10)
            {
                canUseSkill = false;
            }
            else
            {
                canUseSkill = true;
            }
        }
        if (isCooldown)
        {
            CooldownImage2.fillAmount -= 1 / cooldown * Time.deltaTime;
            if (CooldownImage2.fillAmount <= 0)
            {
                CooldownImage2.fillAmount = 0;
                isCooldown = false;
            }
        }

    }
}
