using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cooldown3 : MonoBehaviour
{ 
    [Header("Rock")]
    public Image CooldownImage3;
    public float cooldown = 1;
    bool isCooldown3 = false;
    public KeyCode Rock3;
    public GameObject rockHitEffect;
    public GameObject rockEffect;
    public int rockCost = 15;
    bool isCooldown;
    public Transform firePos;
    public MagicBar MpBar;

    bool canUseSkill;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rock();
    }
    void Rock()
    {
        if (Input.GetKeyDown(KeyCode.K) && isCooldown== false && MpBar.MagicCurrent>=15)
        {
            canUseSkill = true;
            isCooldown= true;
            CooldownImage3.fillAmount = 1;
            MpBar.MagicCurrent -= rockCost;
            Debug.Log("rock");
            Instantiate(rockEffect, firePos.position, firePos.rotation);
            if (MpBar.MagicCurrent <= 0)
            {
                MpBar.MagicCurrent = 0;
            }
            if (MpBar.MagicCurrent > 15)
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
            CooldownImage3.fillAmount -= 1 / cooldown * Time.deltaTime;
            if (CooldownImage3.fillAmount <= 0)
            {
                CooldownImage3.fillAmount = 0;
                isCooldown = false;
            }
        }
    }
}
