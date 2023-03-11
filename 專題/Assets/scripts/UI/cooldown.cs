using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cooldown : MonoBehaviour
{
    public Transform firePos;

    [Header("Fire1")]
    public Image CooldownImage1;
    public float cooldown1 = 1;
    bool isCooldown = false;
    public KeyCode Fire1;
    public GameObject fireHitEffect;
    public GameObject fireEffect;
    public int fireCost = 20;


    public MagicBar MpBar;

    bool canUseSkill;
    void Start()
    {
        CooldownImage1.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }
    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.H) && isCooldown == false&&MpBar.MagicCurrent>=20)
        {
            canUseSkill = true;
            isCooldown = true;
            CooldownImage1.fillAmount = 1;
            MpBar.MagicCurrent -= fireCost;
            Debug.Log("fire");
            Instantiate(fireEffect, firePos.position, firePos.rotation);
            if (MpBar.MagicCurrent<=0)
            {
                MpBar.MagicCurrent = 0;
            }
            if(MpBar.MagicCurrent<20)
            {
                isCooldown = true;
            }
        }
        if(isCooldown)
        {
            CooldownImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;
            if(CooldownImage1.fillAmount<=0)
            {
                CooldownImage1.fillAmount = 0;
                isCooldown = false;
            }
        }
    }
}
