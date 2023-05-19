using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TangDamage : MonoBehaviour
{
    public GameObject tangDamage;

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual float CalculateHP(float hp)
    {
        var hpLeft = hp -= 10;
        return hpLeft;
    }
    public virtual float CalculateDamage(float damage)
    {
        var damageLeft = damage += 10;
        return damageLeft;
    }

}
