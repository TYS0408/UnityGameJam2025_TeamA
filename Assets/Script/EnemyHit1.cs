using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public int HP = 3;//�c��̗�
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    { 
            //�̗͂����炷
            HP--;
        //�̗͂��Ȃ��Ȃ�����
        if(HP <= 0)
        {
            //�������폜
            Destroy(gameObject);
        }
    }

}
