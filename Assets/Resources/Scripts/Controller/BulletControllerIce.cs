using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Pool;

public class BulletControllerIce : BulletController, IceSkill
{

    public GameObject prebIce;
    public void EffIceBounding(GameObject oppoment)
    {
        var affected = oppoment.GetComponent<MoveController>();
        if (affected is null)
        {
            return;
        }
        affected.speed = 0;
    }

    public float Ice(int damage)
    {
        Instantiate(prebIce, this.gameObject.transform.position, this.gameObject.transform.rotation);
        return damage;
    }

    protected override void BulletEx()
    {
        if (time == 300)
        {
            SmartPool.Instance.Spawn(prebIce, this.gameObject.transform.position, this.gameObject.transform.rotation);
            //Instantiate(prebIce, this.gameObject.transform.position, this.gameObject.transform.rotation);

        }
        base.BulletEx();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemyBullet")
        {
            damage += Ice(25);
            EffIceBounding(collision.gameObject);
        }
    }
}
