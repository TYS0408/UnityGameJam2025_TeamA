using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public int HP = 3;//残り体力
    GameController gameController; //ゲーム管理オブジェクト
    void Start()
    {
        //ゲーム管理オブジェクトを取得
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("GameController");
        gameController = gameObjects[0].GetComponent < GameController>();
    }


    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    { 
            //体力を減らす
            HP--;
        //体力がなくなった時
        if(HP <= 0)
        {
            //爆発エフェクト再生
            gameController.playEffect("explosion", gameObject.transform.position);            
            //自分を削除
            Destroy(gameObject);
        }

        //体力が残っている場合
        else
        {
            //命中エフェクト再生
            gameController.playEffect("hit", gameObject.transform.position);
        }

    }

}
