using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaBullet : MonoBehaviour
{
    private float speed = 3;
    private int damage = 10;
    public GameObject peaBulletHitPrefab;

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    void Update()
    {
        // 移动子弹
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // 如果子弹超出屏幕，销毁子弹
        if (transform.position.x > 15)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 碰撞物标签为Zombie时，造成伤害，并销毁子弹
        if (collision.tag == "Zombie")
        {
            collision.GetComponent<Zombie>().TakeDamage(damage);
            GameObject peaBulletHit = Instantiate(peaBulletHitPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject); // 销毁子弹
            Destroy(peaBulletHit, 1); // 1秒后销毁子弹命中特效
        }
    }
}
