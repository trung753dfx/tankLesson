﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Pool;

public class WaveController : MonoBehaviour
{
    public List<EnemyController> _tankEnemy = new List<EnemyController>();
    public EnemyController enemySample;
    [SerializeField] private Transform[] _gate;
    private int _enemyInWave = 0;
    public GameObject heal;
    public GameObject boostDamage;
    float timer;

    // Start is called before the first frame update
    private void Start()
    {
        this.RegisterListener(EventID.EnemyDestroy, (sender, param) =>
        {
            CalculateWave();
        });
        _tankEnemy.Add(enemySample);
        CreateWave();
    }

    public void CreateWave()
    {
        for (int i = 0; i < _tankEnemy.Count; i++)
        {
                var enemy = _tankEnemy[i];
                var gate = Random.Range(0, _gate.Length-1);
            //Instantiate(enemy, _gate[gate].position, _gate[gate].rotation);
            SmartPool.Instance.Spawn(enemySample.gameObject, _gate[gate].position, _gate[gate].rotation);
        }
        }
    

    public void CalculateWave()
    {
        
        _enemyInWave += 1;
        if(_enemyInWave == _tankEnemy.Count)
        {
            if (_tankEnemy.Count <= 10)
            {
                _tankEnemy.Add(enemySample);

                    CreateWave();
                var gateOdd = Random.Range(1, _gate.Length);
                var gateEven = Random.Range(0, _gate.Length/2);
                SmartPool.Instance.Spawn(heal, _gate[gateOdd].position, _gate[gateOdd].rotation);
                SmartPool.Instance.Spawn(boostDamage, _gate[gateEven].position, _gate[gateEven].rotation);
            }
            else
            {
                CreateWave();
                _enemyInWave = 0;
                
            }
        }
    }
    
    //public void CreateEnemy()
    //{
    //    var enemyclone = SmartPool.Instance.Spawn(enemySample.gameObject, this.transform.position, this.transform.rotation);
    //}

    // Update is called once per frame
    void Update()
    {
    }
}



//quy chuan khi viet code code convention
//static viet hoa chu cai dau
//private gach duoi _abc


//thanh level, hien thi slider + text level
//giet 1 enemy + 1 diem cua 1 level
//1 level co 10 diem
//item hoi mau, giam mau
//giet xong 1 wave co 1 khoang nghi, tao 1 binh mau, 1 binh mau hoi 10 HP va 1 binh -10HP +10 Damage
//nghien cuu pooling object

