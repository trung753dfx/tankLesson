using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class PlayerController : TankController
{
    void Update()
    {
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
    }
}
public class Player : SingletonMonoBehaviour<PlayerController>
{
    
}
