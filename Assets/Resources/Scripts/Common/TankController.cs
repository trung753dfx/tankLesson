using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class TankController : MoveController
{
    public Transform bodyTank;
    public Transform gun;
    public BulletController bullet;
    public Transform transhoot;
    public float hp;
    public float level;

    protected override void Move(Vector3 direction)
    {
        if(direction != Vector3.zero)
        {
            bodyTank.up = direction;
        }
        base.Move(direction);
    }

    protected void RotationGun(Vector3 direction)
    {
        gun.up = direction;
    }

    public void Shoot()
    {
        var nametag = Instantiate(bullet, transhoot.transform.position, transhoot.transform.rotation);
        nametag.transform.tag = this.gameObject.transform.tag;
    }

    public void DestroyWhenOutOfHP()
    {
        if (hp <= 0)
        {
            Destroy(this.gameObject);
            gameManager.Instance.genEnemyTank();
            gameManager.Instance.addScore();
        }
    }
}
//Unity co 2 loai Script: minh dinh nghia va unity dinh nghia
//+= tịnh tiến