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

    void OnTriggerEnter(Collider other)
    {
        //体力を減らす
        HP--;
        //体力がなくなった時
        if (HP <= 0)
        {
            //爆発音再生。
            gameController.PlaySE("explosion");
            //爆発エフェクト再生
            gameController.playEffect("explosion", gameObject.transform.position);
            
            //エフェクト削除

            //自分を削除
            Destroy(gameObject);
        }

        //体力が残っている場合
        else
        {
            //命中音再生。
            gameController.PlaySE("hit");
        }
        //命中エフェクト再生
        gameController.playEffect("hit", gameObject.transform.position);
            

    }

}
