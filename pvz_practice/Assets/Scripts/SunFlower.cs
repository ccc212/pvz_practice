using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlower : Plant
{

    public float produceDuration = 5;
    private float produceTimer = 0;
    private Animator animator;
    public GameObject sunPrefab;

    public float jumpMinDistance = 0.3f;
    public float jumpMaxDistance = 2;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ProduceSun()
    {
        GameObject sun = GameObject.Instantiate(sunPrefab, transform.position, Quaternion.identity);

        float jumpDistance = Random.Range(jumpMinDistance, jumpMaxDistance);
        float jumpDirection = Random.Range(0, 2) < 1 ? -1 : 1;
        Vector3 jumpTarget = transform.position + new Vector3(jumpDistance * jumpDirection, 0, 0);

        sun.GetComponent<Sun>().JumpTo();
    }

    protected override void EnableUpdate()
    {
        produceTimer += Time.deltaTime;

        if (produceTimer >= produceDuration)
        {
            animator.SetTrigger("IsGlowing");
        }
    }
}
