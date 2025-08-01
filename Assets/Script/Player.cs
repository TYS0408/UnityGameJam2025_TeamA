using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Sprite spriteNomal;  //プレイヤーの通常スプライト
    public Sprite spriteDown;   //プレイヤーの下降スプライト
    public Sprite spriteUp;     //プレイヤーの上昇スプライト

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //移動量。
        Vector3 moveVec;

        //プレイヤー移動
        {
            //マウス座標取得。
            Vector3 pos = Input.mousePosition;
            //マウス座標をワールド座標に変換。
            pos.z = -Camera.main.transform.position.z;
            //スクリーン座標をワールド座標に転換。
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(pos);
            //現在位置からマウスワールド位置までの移動量。
            moveVec = (worldPos - transform.position) / 30;
            //徐々にマウス座標に近づくよう、移動量を分割して加算
            transform.position += moveVec;
        }

        //上下の移動量に応じてスプライトを切り替え。
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (Mathf.Abs(moveVec.y) < 0.05f)
        {
            //縦の移動量が0.05未満なら通常スプライト。
            spriteRenderer.sprite = spriteNomal;
        }
        else
        {
            if (moveVec.y < 0)
            {
                //縦の移動量がマイナスなら下降スプライト。
                spriteRenderer.sprite = spriteDown;
            }
            else
            {
                //縦の移動量がプラスなら上昇スプライト。
                spriteRenderer.sprite = spriteUp;
            }

        }
        
    }
}
