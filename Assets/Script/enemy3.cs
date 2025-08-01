using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy3 : MonoBehaviour
{
    public float speed = 40;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //現在の座標を取得
        Vector3 pos = transform.position;

        //進行方向に向かって直進
        pos += -transform.right * speed * Time.fixedDeltaTime;

        //新しい座標に登録
        transform.position = pos;
    }
}
