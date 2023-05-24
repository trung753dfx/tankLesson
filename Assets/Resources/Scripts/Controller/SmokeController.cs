using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class SmokeController : MonoBehaviour
{
    public GameObject explosion;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroySmoke()
    {
        PoolingObject.DestroyPooling<SmokeController>(this);
        //Debug.LogError("destroy pooling");
    }
}
