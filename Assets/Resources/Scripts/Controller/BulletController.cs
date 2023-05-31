using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;
using Core.Pool;

public class BulletController : MoveController
{

    public float time = 0;
    public SmokeController explosion;
    public BulletController bullet;
    public float damage;
    // Update is called once per frame
    public void Update()
    {
        if (time == 500)
        {
            //PoolingObject.DestroyPooling<BulletController>(this);
            SmartPool.Instance.Despawn(bullet.gameObject);
            //CreateSmoke();
            //Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
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
            //PoolingObject.DestroyPooling<BulletController>(this);
            SmartPool.Instance.Despawn(this.gameObject);
            //CreateSmoke();
            //Instantiate(this.explosion, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
    public void CreateSmoke()
    {
        //SmokeController smokeclone = PoolingObject.createPooling<SmokeController>(explosion);
        //if (smokeclone == null)
        //{
        //    return Instantiate(explosion, this.transform.position, this.transform.rotation);
        //    //Debug.LogError("pooling");
        //}
        //return smokeclone;
        var smokeclone = SmartPool.Instance.Spawn(explosion.gameObject, this.transform.position, this.transform.rotation);
    }

    protected virtual void BulletEx()
    {
        if (time == 30)
        {
            SmartPool.Instance.Despawn(this.gameObject);
            Instantiate(this.gameObject, this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
        time++;
    }
}