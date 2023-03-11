using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicBar : MonoBehaviour
{
    public Text MagicText;
    public int MagicCurrent;
    public int MagicMax=100;
    public float timer;

    private Image MpBar;
    bool start=true;

    void Start()
    {
        MpBar = GetComponent<Image>();
        MagicCurrent = MagicMax;
        
    }

    // Update is called once per frame
    void Update()
    {
        MpBar.fillAmount = (float)MagicCurrent / (float)MagicMax;
        MagicText.text = MagicCurrent.ToString() + "/" + MagicMax.ToString();
        Magic();
        if(start)
        {
            timer += Time.deltaTime;
            if(timer>=1f)
            {
                MagicCurrent += 5;
                timer = 0f;
            }
        }
    }
    void Magic()
    {
        if(MagicCurrent>MagicMax)
        {
            MagicCurrent = MagicMax;
        }
    }
}
