using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : MonoBehaviour
{
    //動きの種類
    public enum ENEMY_TYPE
    {
        LINE, //直進
        CURVE　//上下にカーブ
    }

    public ENEMY_TYPE type = ENEMY_TYPE.CURVE;
    public float speed = 3;//1秒間に進む距離
    public float cycleCount = 2;//1秒間に往復する回数
    public float curveLength = 3;　//カーブの最大距離
     float cycleRadian =0;　//Mathf.sin()に渡す角度(ラジアン).
    float centerY;//上下移動の中心y座標
    void Start()
    {
        //初期y座標を「y座標の中心」として保存する
        centerY = transform.position.y;//ゲーム開始時に現在のY座標を基準位置として記録
    }


    void Update()
    {
        
    }

    //物理挙動を行うため、FixedUpdate()メゾットを使う
    private void FixedUpdate()
    {
        //現在の座標を取得
        Vector3 pos = transform.position;

        //進行方向に向かって直進
        pos += -transform.right//←オブジェクトの右方向ベクトル(X軸方向)
     * speed * Time.fixedDeltaTime;//→物理更新間隔の時間(通常0.02秒）
        //上下にカーブ
        if (type == ENEMY_TYPE.CURVE)
        {
            if(cycleCount > 0)
            {
                cycleRadian += (cycleCount * 2 * Mathf.PI) / 50; //→ 1秒間のラジアン変化量（1周期=2πラジアン）
                pos.y = Mathf.Sin(cycleRadian) * curveLength + centerY;
                //Mathf.Sin(cycleRadian)→サインは波で上下運動
                //* curveLength→上下振れ幅調整
                //+centerY→基準位置を中心に上下移動
            }
        }
        //新しい座標に変更
        transform.position = pos;
    }

}
