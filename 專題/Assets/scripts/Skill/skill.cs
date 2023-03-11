using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skill : MonoBehaviour
{
    [Header("Fire")]
    public float fireDamage = 20;
    public GameObject fireHitEffect;
    public GameObject fireEffect;
    public Image CooldownImage1;
    public float cooldown1 = 1;
    bool isCooldown = false;
    public KeyCode Fire1;



    [Header("Water")]
    public float waterDamage = 10;
    public GameObject waterHitEffect;
    public GameObject waterEffect;
    public Image CooldownImage2;
    public float cooldown2 = 1;
    bool isCooldown2 = false;
    public KeyCode Water2;


    [Header("Rock")]
    public float rockDamage = 15;
    public GameObject rockHitEffect;
    public GameObject rockEffect;
    public Image CooldownImage3;
    public float cooldown3 = 1;
    bool isCooldown3 = false;
    public KeyCode Rock3;


    public MagicBar MpBar;




    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && isCooldown == false && MpBar.MagicCurrent >= 20)
        {
            isCooldown = true;
            CooldownImage1.fillAmount = 1;
            MpBar.MagicCurrent -= 20;
            Debug.Log("fire");
            Instantiate(fireEffect, transform.position, transform.rotation);
            if (MpBar.MagicCurrent <= 0)
            {
                MpBar.MagicCurrent = 0;
            }
        }
        if (isCooldown)
        {
            CooldownImage1.fillAmount -= 1 / cooldown2 * Time.deltaTime;
            if (CooldownImage1.fillAmount <= 0)
            {
                CooldownImage1.fillAmount = 0;
                isCooldown = false;
            }
        }
        //  Water();
        //  Rock();
        // if (Input.GetKeyDown(KeyCode.H))
        // {
        //   Debug.Log("fire");
        //    Instantiate(fireEffect, transform.position, transform.rotation);


        //  }

        //  if (Input.GetKeyDown(KeyCode.J))
        //   {
        //     Debug.Log("water");
        //     Instantiate(waterEffect, transform.position, transform.rotation);

        //   }

        //   if (Input.GetKeyDown(KeyCode.K))
        //  {
        //      Debug.Log("rock");
        //       Instantiate(rockEffect, transform.position, transform.rotation);

        //  }

    }
    void Start()
    {
    }
    void Fire()
    {
       /* if (Input.GetKeyDown(KeyCode.H) && isCooldown == false && MpBar.MagicCurrent >= 20)
        {
            isCooldown = true;
            CooldownImage1.fillAmount = 1;
            MpBar.MagicCurrent -= 20;
            Debug.Log("fire");
            Instantiate(fireEffect, transform.position, transform.rotation);
            if (MpBar.MagicCurrent <= 0)
            {
                MpBar.MagicCurrent = 0;
            }
        }
        if (isCooldown)
        {
            CooldownImage1.fillAmount -= 1 / cooldown2 * Time.deltaTime;
            if (CooldownImage1.fillAmount <= 0)
            {
                CooldownImage1.fillAmount = 0;
                isCooldown = false;
            }
        }*/
    }
}