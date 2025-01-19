using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ZombieState
{
    Move,
    Attack,
    Die
}

public class Zombie : MonoBehaviour
{
    private ZombieState zombieState = ZombieState.Move;
    private Rigidbody2D rgd;
    public float moveSpeed = 1.5f;
    private Animator anim;

    void Start()
    {
        rgd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        switch (zombieState)
        {
            case ZombieState.Move:
                MoveUpdate();
                break;
            case ZombieState.Attack:
                AttackUpdate();
                break;
            case ZombieState.Die:
                DieUpdate();
                break;
            default:
                break;
        }
    }

    void MoveUpdate()
    {
        rgd.MovePosition(rgd.position + Vector2.left * moveSpeed * Time.deltaTime);
    }

    void AttackUpdate()
    {

    }

    void DieUpdate()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Plant")
        {
            anim.SetBool("IsAttacking", true);
            zombieState = ZombieState.Attack;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Plant")
        {
            anim.SetBool("IsAttacking", false);
            zombieState = ZombieState.Move;
        }
    }
}
