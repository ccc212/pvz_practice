using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public float moveDuration = 1;
    public int point = 25;
    public float moveSpeed = 5.0f;
    public float aliveTime = 10;
    private float aliveTimer = 0;
    void Update()
    {
        aliveTimer += Time.deltaTime;
        if (aliveTimer >= aliveTime)
        {
            DestroySun();
        }
    }

    // 闪烁三次后销毁阳光
    public void DestroySun()
    {
        // TODO: 闪烁三次
        
        // 销毁阳光
        Destroy(gameObject);
    }

    // 跳跃到目标位置
    public void JumpTo(Vector3 targetPos)
    {
        Vector3 centerPos = (transform.position + targetPos) / 2;
        float distance = Vector3.Distance(transform.position, targetPos);

        centerPos.y += distance / 2;

        transform.DOPath(new Vector3[] { transform.position, centerPos, targetPos },
            moveDuration,
            PathType.CatmullRom)
            .SetEase(Ease.OutQuad);
    }

    // 直线移动到目标位置
    public void LinearMoveTo(Vector3 targetPos)
    {
        float distance = Vector3.Distance(transform.position, targetPos);
        float moveDuration = distance / moveSpeed;
        transform.DOMove(targetPos, moveDuration).SetEase(Ease.Linear);
    }

    // 鼠标点击阳光，阳光跳跃到阳光点，并销毁阳光
    public void OnMouseDown()
    {
        transform.DOMove(SumManager.instance.GetSunPointTextPosition(), moveDuration)
        .SetEase(Ease.OutQuad)
        .OnComplete(() => Destroy(gameObject));
        SumManager.instance.AddSunPoint(point);
    }
}