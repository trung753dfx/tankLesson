using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LTAUnityBase.Base.DesignPattern;

public class GameManager : MonoBehaviour
{
    public EnemyController tankEnemy;
    public int scorePlayer;
    public Text scoreTxt;

    // Update is called once per frame
    
    private void Awake()
    {
        //Observer.Instance.AddObserver(TOPICNAME.ENEMYDESTROY, addScore);
        //Observer.Instance.AddObserver(TOPICNAME.ENEMYDESTROY, genEnemyTank);
    }
    private void Update()
    {
        scoreTxt.text = "Score : " + scorePlayer.ToString();
    }
    public void addScore(/*object data*/)
    {
        scorePlayer += 10;
    }
    public void genEnemyTank()
    {
        Instantiate(tankEnemy, gameManager.Instance.transform.position, gameManager.Instance.transform.rotation);
        Instantiate(tankEnemy, gameManager.Instance.transform.position + Vector3.up, gameManager.Instance.transform.rotation);
    }
}
public class gameManager : SingletonMonoBehaviour<GameManager>
{

}
//RAM: 2 vùng nhớ stack và heap
//static, string lưu vào heap
//stack sẽ lưu theo một khoảng thời gian (khi nào đầy sẽ clean)
//Awake > Start > Update, awake chỉ gọi một lần duy nhất
//Singleton chỉ tạo awake khi class là MonoBehavior


//3 nguyen tac cua Jin
//Doc va phan tich diem chung
//Diem chung day thi viet 1 class
//Nhung class con ke thua class tren


//Nghien cuu them observer
//btvn ghep UI