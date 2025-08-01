using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class enemy1 : MonoBehaviour
{
    //動きの種類
    public enum ENEMY_TYPE
    {
        LINE,
        CURVE
    }

    //動きの種類
    public ENEMY_TYPE type = ENEMY_TYPE.CURVE;

    

    public float speed = 20; //1秒間に進む距離
    //物理更新時に処理
    private void FixedUpdate()
    {
        //現在の座標を取得
        Vector3 pos = transform.position;

        //進行方向に向かって直進
        pos += -transform.right * speed * Time.fixedDeltaTime;
        //上下にカーブ
        if(type == ENEMY_TYPE.CURVE)
        {
            if(cycleCount > 0)
            {
                cycleRadian += (cycleCount * 2 * Mathf.PI) / 50;
                pos.y = Mathf.Sin(cycleRadian) * curveLength + centerY;
            }
        }

        //新しい座標に変更
        transform.position = pos;
    }

    public float cycleCount = 1;//1秒間に往復する回数
    public float curveLength = 2;//カーブの最大距離
    float cycleRadian = 0;//サインに渡す値
    float centerY; //Y座標の中心
    void Start()
    {
        //初期y座標を「y座標の中心」として保存する
        centerY = transform.position.y;
    }


    void Update()
    {
    }
}
