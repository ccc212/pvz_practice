using UnityEngine;

public class Peashooter : Plant
{
    public float shootDuration = 2;
    private float shootTimer = 0;
    public Transform shootPointTransform;
    public PeaBullet peaBulletPrefab;
    public float peaBulletSpeed = 5;

    protected override void EnableUpdate()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootDuration)
        {
            shootTimer = 0;
            Shoot();
        }
    }

    void Shoot()
    {
        PeaBullet peaBullet = Instantiate(peaBulletPrefab, shootPointTransform.position, Quaternion.identity);
        peaBullet.SetSpeed(peaBulletSpeed);
    }
}

