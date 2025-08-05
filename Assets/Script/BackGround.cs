using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float speed = 0.01f; // 背景の移動速度
    public float scrollWidth = 5.44f; // スクロールする幅

    // Start is called before the first frame update
    void Start()
    {
        //自分のスケールに合わせて「ループの幅」を計算。
        scrollWidth *= transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //物理演算時に処理。
    void FixedUpdate()
    {
        //スクロール。
        Vector3 pos = transform.position;
        pos.x -= speed;
        //ループ幅を越えて移動した場合。
        if (-scrollWidth > pos.x)
        {
            //ループ幅を元に戻す。
            pos.x += scrollWidth;
        }
        transform.position = pos;

    }
}
