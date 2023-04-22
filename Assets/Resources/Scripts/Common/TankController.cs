using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MoveController
{
    public Transform bodyTank;
    public Transform gun;
    public GameObject bullet;
    public Transform transhoot;

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

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, vertical);

        if(direction != Vector3.zero)
        {
            this.gameObject.transform.up = direction;
        }

        bodyTank.transform.position += direction * Time.deltaTime * speed;

        Vector3 gunDirection = new Vector3(
            Input.mousePosition.x - Screen.width / 2,
            Input.mousePosition.y - Screen.width / 2
            );

        gun.transform.up = gunDirection;
        //gun2.transform.up = gunDirection;

        if (Input.GetMouseButton(0))
        {
            /*if(Instantiate(bullet, transhoot.transform.position, transhoot.transform.rotation))
            {
                //Instantiate(bullet1, transhoot2.transform.position, transhoot2.transform.rotation);
                //Instantiate(bullet1, transhoot3.transform.position, transhoot2.transform.rotation);
                //Instantiate(bullet1, transhoot4.transform.position, transhoot2.transform.rotation);
            }*/
            var playerBullet = Instantiate(bullet, transhoot.transform.position, transhoot.transform.rotation);
            playerBullet.transform.tag = "playerBullet";
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.CompareTag("enemyBullet"))
        {
            //Destroy(this.gameObject);
        }
    }
}

//Unity co 2 loai Script: minh dinh nghia va unity dinh nghia
//+= tịnh tiến