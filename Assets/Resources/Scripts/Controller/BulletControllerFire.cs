using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControllerFire : BulletController, FireSkill
{
    public GameObject prebFire;
    //public float time==0; 

    public void EffFireBounding(GameObject oppoment)
    {
        var affected = oppoment.GetComponent<EnemyController>();
        time = 0;
        if (affected is null)
        {
            return;
        }
        affected.hp -= 20 * time*Time.deltaTime;
        time++;
    }

    public float Fire(int damage)
    {
        Instantiate(prebFire, this.gameObject.transform.position, this.gameObject.transform.rotation);
        return damage;
    }
    protected override void BulletEx()
    {
        if (time == 300)
        {
            //SmartPool.Instance.Spawn(prebIce, this.gameObject.transform.position, this.gameObject.transform.rotation);
            Instantiate(prebFire, this.gameObject.transform.position, this.gameObject.transform.rotation);

        }
        base.BulletEx();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemyBullet")
        {
            damage += Fire(25);
            EffFireBounding(collision.gameObject);
        }
    }
}
