using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHit2 : MonoBehaviour
{
    public int HP = 3;//�̗�
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //�̗͂����炷
        HP--;
        //�̗͂��Ȃ��Ȃ����Ƃ�
        if( HP <= 0)
        {
            //�������폜
            Destroy(gameObject);
        }
    }
}
