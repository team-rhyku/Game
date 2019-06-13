//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class playerAttack : MonoBehaviour
//{
//    private bool attacking = false;
//    private float attackTimer = 0;
//    private float attacked = 0.3f;

//    public Collider2D attacktrigger;
//    private Animator anim;

//    void Awake()
//    {
//        anim = gameObject.GetComponent<Animator>();
//        attacktrigger.enabled = false;
//    }

//    void Update()
//    {
//        if(Input.GetKeyDown("f") && !attacking)
//        {
//            attacking = true;
//            attackTimer = attacked;

//            attacktrigger.enabled = true;
//        }

//        if(attacking)
//        {
//            if(attackTimer > 0)
//            {
//                attackTimer -= Time.deltaTime;
//            }
//            else
//            {
//                attacking = false;
//                attacktrigger.enabled = false;

//            }
//        }
//        anim.SetBool("Attacking", attacking);
        
//    }
//}
