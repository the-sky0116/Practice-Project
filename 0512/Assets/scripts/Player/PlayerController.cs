using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<Skill> skills;
    [SerializeField]
    private int skillIndex = 0;

    public GameObject owner;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Skill skill in skills)
            skill.Initialize(owner);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            skillIndex--;
            if (skillIndex < 0)
                skillIndex = skills.Count - 1;
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            skillIndex++;
            if (skillIndex > skills.Count - 1)
                skillIndex = 0;
        }
        else if (Input.GetKeyDown(KeyCode.E))
            skills[skillIndex].Use();
    }
}
