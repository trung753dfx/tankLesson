using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LTAUnityBase.Base.DesignPattern;

public class PlayerController : TankController
{
    public Slider slider_hp;
    public GameObject hpPoint;
    public Text levelTxt;
    public GameObject levelPoint;
    public Slider slider_level;
    private void Awake()
    {
        slider_hp.maxValue = hp;
    }

    void Update()
    {
        //
        slider_hp.value = hp;
        if (hp <= 0)
        {
            Destroy(this.gameObject);
            hpPoint.gameObject.SetActive(false);
        }
        //

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, vertical);
        Move(direction);
        Vector3 gunDirection = new Vector3(
            Input.mousePosition.x - Screen.width / 2,
            Input.mousePosition.y - Screen.height / 2
            );
        var position = Input.mousePosition;
        RotationGun(gunDirection);
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        DestroyWhenOutOfHP();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.CompareTag("enemyBullet"))
        {
            hp = bullet.CalculateHP(hp, level);
            //Destroy(this.bullet);
            Instantiate(bullet.explosion, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
    
public class Player : SingletonMonoBehaviour<PlayerController>
{
    
}
