using UnityEngine;

public class Peashooter : Plant
{
    public float shootDuration = 2;
    private float shootTimer = 0;
    public Transform shootPointTransform;
    public PeaBullet peaBulletPrefab;
    public float peaBulletSpeed = 5;
    public int damage = 20;

    // 启用时才开始射击
    protected override void EnableUpdate()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootDuration)
        {
            shootTimer = 0;
            Shoot();
        }
    }

    // 射击
    void Shoot()
    {
        PeaBullet peaBullet = Instantiate(peaBulletPrefab, shootPointTransform.position, Quaternion.identity);
        peaBullet.SetSpeed(peaBulletSpeed);
        peaBullet.SetDamage(damage);
    }
}
    