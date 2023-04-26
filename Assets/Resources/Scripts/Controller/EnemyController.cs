using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class EnemyController : TankController
{
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
        //Destroy khi het HP
        DestroyWhenOutOfHP();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.CompareTag("Player"))
        {
            hp = bullet.CalculateHP(hp, level);
            DestroyWhenOutOfHP();
        }    
    }
}
//tim hieu OOP, nam duoc 4 thuoc tinh
//tim hieu mo hinh MVC
//on tap bai tap Tank
//codesignal (1-10)




//Viet lai luong
//Viet method kiem tra mau, khi nao enemy hp = 0 -> ban Observer -> sinh doi
//Toi uu code virtual override Destroy khi <= 0
//On lai OOP (chep phat)
//Object duoc goi tu Awake
//Ham dac biet disable/enable/destroy/fixupdate/lateupdate