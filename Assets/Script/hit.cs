using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : MonoBehaviour
{
    public int energy = 3;      //残り体力。

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        void OnTriggeerEnger2D(Collider2D collider)
        {
            //体力を減らす。
            energy--;
            //体力が０になったらオブジェクトを削除する。
            if(energy<=0)
            {
                Destroy(gameObject);
            }
        }
    }
}
