using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int fireballDamage = 10;
    [SerializeField] private int waterDamage = 15;
    [SerializeField] private int rockDamage = 20;
    public int Health = 100;
    public int Magic = 100;
    public float dieTime;
    bool isdead;
    private Animator anim;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            healthBar.HealthCurrent = 100;
            Health = 100;
        }
    }
    void KillPlayer()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("levelone");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "flower")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2();
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 2000);
        }
        if (other.tag == ("attackEnemy"))
        {
            Debug.Log("hurt");
            healthBar.HealthCurrent = Health;
            Health -= 15;

            if (Health <= 0)
            {
                Health=0;
                isdead = true;
                Invoke("KillPlayer", dieTime);

                GetComponent<Animator>().SetBool("dead", isdead);

            }

        }
        if (other.gameObject.CompareTag("hurt"))
        {
            Health -= 100;
            isdead = true;
            Invoke("KillPlayer", dieTime);

            GetComponent<Animator>().SetBool("dead", isdead);
            if (dieTime == 0)
            {
                this.gameObject.SetActive(false);
            }


        }
    }



}
