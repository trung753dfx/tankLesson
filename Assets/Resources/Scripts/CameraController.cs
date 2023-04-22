using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Transform tank = Player.Instance.transform;
        Vector3 newPos = new Vector3(tank.position.x, tank.position.y, -20f);
        transform.position = Vector3.Lerp(transform.position, newPos, 0.05f);

    }
}
