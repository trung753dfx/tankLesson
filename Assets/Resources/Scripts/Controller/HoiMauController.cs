using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoiMauController : MonoBehaviour
{

    public GameObject hoiMau;
    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual float CalculateHP(float hp)
    {
        var hpLeft = hp += 10;
        return hpLeft;
    }
}
