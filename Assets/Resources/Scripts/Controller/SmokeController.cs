using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;
using Core.Pool;

public class SmokeController : MonoBehaviour
{
    public GameObject explosion;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroySmoke()
    {
        //PoolingObject.DestroyPooling<SmokeController>(this);
        //Debug.LogError("destroy pooling");
        SmartPool.Instance.Despawn(this.gameObject);
    }
}
