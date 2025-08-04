using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit3 : MonoBehaviour
{
    GameController gameController; //ゲーム管理オブジェクト
    public int HP = 3;
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
            if(HP<=0)
        {
            //爆発エフェクト再生
            gameController.playEffect("explosion", gameObject.transform.position);
            //自分を削除
            Destroy(gameObject);
        }
    }
}
