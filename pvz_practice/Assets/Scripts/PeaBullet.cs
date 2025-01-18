using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaBullet : MonoBehaviour
{
    private float speed = 3;

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
}
