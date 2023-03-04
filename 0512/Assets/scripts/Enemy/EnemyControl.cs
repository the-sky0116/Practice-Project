using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    #region public Variables
    public Transform rayCast;
    public LayerMask raycastMask;
    public float rayCastLength;
    public float attackDistance;
    public float moveSpeed;
    public float timer;

    #endregion
    #region private Variables
    private RaycastHit2D hit;
    private Transform target;
    private Animator anim;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float intTimer;

    public Transform LeftLimit;
    public Transform RightLimit;
    #endregion

    #region Health Variable
    [SerializeField]private int Health;
    [SerializeField]private int Damage;
    private PlayerHeal playerHeal;
    #endregion

    void Awake()
    {
        SelectTarget();
        intTimer = timer;
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        if(!attackMode)
        {
            Move();
        }
        if(!InsideOfLimits()&&!inRange&&!anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Attack"))
        {
            SelectTarget();
        }

        if(inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, transform.right, rayCastLength, raycastMask);
            RaycastDebugger();
        }
        if(hit.collider!=null)
        {
            EnemyLogic();
        }
        else if(hit.collider==null)
        {
            inRange = false; 
        }
        if(inRange==false)
        {
            StopAttack();
        }
    }
    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.tag=="Player")
        {
            target = trig.transform;
            inRange = true;
            Flip();
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);
        if(distance>attackDistance)
        {
            StopAttack();
        }
        else if(attackDistance>=distance&&cooling==false)
        {
            Attack();
        }
        if(cooling)
        {
            anim.SetBool("Attack", false);
        }
    }
    void Move()
    {
        anim.SetBool("canWalk", true);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Attack"))
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        timer = intTimer;
        attackMode = true;

        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", true);
    }
    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack", false);
    }
    void RaycastDebugger()
    {
        if(distance>attackDistance)
        {
            Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.red);
        }
        else if(attackDistance>distance)
        {
            Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.green);
        }
    }
    public void TriggerCooling()
    {
        cooling = true;
    }
    private bool InsideOfLimits()
    {
        return transform.position.x > LeftLimit.position.x && transform.position.x < RightLimit.position.x;
    }
        
    private void SelectTarget()
    {
        float distanceToLeft=Vector2.Distance(transform.position, LeftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position, RightLimit.position);

        if(distanceToLeft>distanceToRight)
        {
            target = LeftLimit;
        }
        else
        {
            target = RightLimit;
        }
        Flip();
    }
    private void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if(transform.position.x>target.position.x)
        {
            rotation.y = 0f;
        }
        else
        {
            rotation.y = 180f;
        }
        transform.eulerAngles = rotation;
    }

}