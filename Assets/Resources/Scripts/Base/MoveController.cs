using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float speed;
    protected virtual void Move(Vector3 direction)
    {
        this.transform.position += direction * Time.deltaTime * speed;
    }
}

//hoc tiep SO-(LID)
//nghien cuu pooling object (design patern)
//on lai kien thuc cu (buoi hom nay)
//Time.deltaTime (mot frame)