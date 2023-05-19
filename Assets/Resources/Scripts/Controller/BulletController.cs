using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class BulletController : MoveController
{

    public float time = 0;
    public GameObject explosion;
    public float damage;
    // Update is called once per frame
    void Update()
    {
        if (time == 200)
        {
            PoolingObject.DestroyPooling<BulletController>(this);
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.tag != this.gameObject.tag)
        {
            PoolingObject.DestroyPooling<BulletController>(this);
            Instantiate(this.explosion, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}