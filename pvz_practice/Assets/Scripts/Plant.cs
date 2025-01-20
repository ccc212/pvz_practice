using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlantState
{
    Disable,
    Enable
}

public class Plant : MonoBehaviour
{
    PlantState plantState = PlantState.Disable;
    public PlantType plantType = PlantType.SunFlower;
    public int hp = 100;

    private void Start()
    {
        // 初始化时，禁用植物
        TransitionToDisable();
    }

    private void Update()
    {
        switch (plantState)
        {
            case PlantState.Disable:
                DisableUpdate();
                break;
            case PlantState.Enable:
                EnableUpdate();
                break;
            default:
                break;
        }
    }

    void DisableUpdate()
    {

    }

    protected virtual void EnableUpdate()
    {

    }

    // 禁用
    public void TransitionToDisable()
    {
        plantState = PlantState.Disable;
        GetComponent<Animator>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }

    // 启用
    public void TransitionToEnable()
    {
        plantState = PlantState.Enable;
        GetComponent<Animator>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }

    // 受伤
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }

    // 死亡
    private void Die()
    {
        Destroy(gameObject);
    }
}

