using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TangSpd : MonoBehaviour
{
    public GameObject tangSpd;
    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual float ChangeSpeed(float speed)
    {
        var currentSpeed = speed += 1;
        return currentSpeed;
    }
}
