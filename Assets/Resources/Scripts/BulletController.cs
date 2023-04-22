using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MoveController
{

    private float time = 0;
    public GameObject explosion;
    
    // Update is called once per frame
    void Update()
    {
        if (time == 100)
        {
            Destroy(this.gameObject);
            Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        }
        time++;
        //this.transform.position += transform.up * Time.deltaTime * speed;
        Move(transform.up);

    }
}

//Time.deltaTime là thời gian trong một frame
//BTVN xe tăng không lật hình khi di chuyển xuống (cha thay đổi, con thay đổi, con thay đổi, cha không thay đổi)
//BTVN2 nòng dài, di chuyển và bắn ra hướng cùng nhau