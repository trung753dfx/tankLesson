using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MoveController
{

    private float time = 0;
    public GameObject explosion;
    public float damage;

    // Update is called once per frame
    void Update()
    {
        if (time == 200)
        {
            Destroy(this.gameObject);
            Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        }
        time++;
        Move(transform.up);
    }
    public virtual float CalculateHP(float hp, float level)
    {
        var hpLeft = hp - (level + damage);
        return hpLeft;
    }
    public void DestroyWhenImpact()
    {

    }
}