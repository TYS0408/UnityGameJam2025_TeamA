using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public int HP = 3;//�c��̗�
    GameController gameController; //�Q�[���Ǘ��I�u�W�F�N�g
    void Start()
    {
        //�Q�[���Ǘ��I�u�W�F�N�g���擾
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("GameController");
        gameController = gameObjects[0].GetComponent < GameController>();
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
            //�����G�t�F�N�g�Đ�
            gameController.playEffect("explosion", gameObject.transform.position);            
            //�������폜
            Destroy(gameObject);
        }

        //�̗͂��c���Ă���ꍇ
        else
        {
            //�����G�t�F�N�g�Đ�
            gameController.playEffect("hit", gameObject.transform.position);
        }

    }

}
