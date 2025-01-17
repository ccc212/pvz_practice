using DG.Tweening;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public float moveDuration = 1;
    public int point = 25;
    public float moveSpeed = 5.0f;

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

    public void LinearMoveTo(Vector3 targetPos)
    {
        float distance = Vector3.Distance(transform.position, targetPos);
        float moveDuration = distance / moveSpeed;
        transform.DOMove(targetPos, moveDuration).SetEase(Ease.Linear);
    }

    public void OnMouseDown()
    {
        transform.DOMove(SumManager.instance.GetSunPointTextPosition(), moveDuration)
        .SetEase(Ease.OutQuad)
        .OnComplete(() => Destroy(gameObject));
        SumManager.instance.AddSunPoint(point);
    }
}