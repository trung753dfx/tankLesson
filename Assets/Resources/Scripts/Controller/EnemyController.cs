using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class EnemyController : TankController
{

    // Update is called once per frame
    private void Update()
    {
        //Move
        Vector3 direction = Player.Instance.transform.position;

        //Rotate
        var gunDirection = direction - transform.position;
        var newDic = new Vector3(gunDirection.x, gunDirection.y);
        Move(newDic);
        RotationGun(newDic);
        //Shoot
        if (Random.Range(0, 200) % 50 == 0)
        {
            Shoot();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.CompareTag("playerBullet"))
        {
            Destroy(this.gameObject);
            //gameManager.Instance.addScore();
            //gameManager.Instance.genEnemyTank();
            Observer.Instance.Notify(TOPICNAME.ENEMYDESTROY);
        }    
    }
}
//tim hieu OOP, nam duoc 4 thuoc tinh
//tim hieu mo hinh MVC
//on tap bai tap Tank
//codesignal (1-10)