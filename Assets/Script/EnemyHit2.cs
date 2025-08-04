using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHit2 : MonoBehaviour
{
    public int HP = 3;//体力
    GameController gameController; //ゲーム管理オブジェクト
    void Start()
    {
        //ゲーム管理オブジェクトを取得
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("GameController");
        gameController = gameObjects[0].GetComponent<GameController>();
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //体力を減らす
        HP--;
        //体力がなくなったとき
        if( HP <= 0)
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
