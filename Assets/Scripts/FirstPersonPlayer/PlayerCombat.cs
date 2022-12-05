using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            Debug.Log("Attacked");
            Attack();
        }
    }

    void Attack()
    {
        // Play an attack animation
        // Detect enemies in range of attack
        // Damage them


        anim.SetTrigger("AttackWithSword");
    }
}
