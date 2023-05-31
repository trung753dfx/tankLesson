using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface FireSkill
{
    float Fire(int damage);
    void EffFireBounding(GameObject oppoment);
}