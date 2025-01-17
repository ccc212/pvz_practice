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

    public int attackDamage = 10;
    public float attackDuration = 2;
    private float attackTimer = 0;

    private Plant targetPlant;

    public int hp = 100;
    private int currentHp;
    public GameObject zombieHeadPrefab;
    private bool hasDroppedHead = false;

    void Start()
    {
        rgd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHp = hp;
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

    // 移动
    void MoveUpdate()
    {
        rgd.MovePosition(rgd.position + Vector2.left * moveSpeed * Time.deltaTime);
    }

    // 攻击
    void AttackUpdate()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackDuration && targetPlant != null)
        {
            attackTimer = 0;
            targetPlant.TakeDamage(attackDamage);
        }
    }

    // 死亡
    void DieUpdate()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 碰撞物标签为Plant时，执行攻击动画，并获取目标植物
        if (collision.tag == "Plant")
        {
            anim.SetBool("IsAttacking", true);
            TransitionToAttack();
            targetPlant = collision.GetComponent<Plant>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // 离开时，关闭攻击动画，并设置目标植物为null
        if (collision.tag == "Plant")
        {
            anim.SetBool("IsAttacking", false);
            zombieState = ZombieState.Move;
            targetPlant = null;
        }
    }

    void TransitionToAttack()
    {
        zombieState = ZombieState.Attack;
        attackTimer = 0; // 重置攻击计时器，以确保下次碰到植物后重新开始计时
    }

    public void TakeDamage(int damage)
    {
        if (currentHp <= 0) return;

        currentHp -= damage;
        if (currentHp <= 0)
        {
            currentHp = -1;
            Die();
        }
        float hpPercentage = (float)currentHp / hp;
        anim.SetFloat("HpPercent", hpPercentage);

        if (hpPercentage <= 0.3 && !hasDroppedHead)
        {
            GameObject zombieHead = Instantiate(zombieHeadPrefab, transform.position, Quaternion.identity);
            Destroy(zombieHead, 2); // 2秒后销毁掉落的头
            hasDroppedHead = true;
        }
    }

    void Die()
    {
        zombieState = ZombieState.Die;
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 2); // 2秒后销毁
    }
}

