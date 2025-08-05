using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit3 : MonoBehaviour
{
    GameController gameController; //�Q�[���Ǘ��I�u�W�F�N�g
    public int HP = 3;
        void Start()
    {
        //�Q�[���Ǘ��I�u�W�F�N�g���擾
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("GameController");
        gameController = gameObjects[0].GetComponent<GameController>();
    }


    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        //�̗͂����炷
        HP--;
        //�̗͂��Ȃ��Ȃ�����
        if (HP <= 0)
        {
            //�������Đ��B
            gameController.PlaySE("explosion");
            //�����G�t�F�N�g�Đ�
            gameController.playEffect("explosion", gameObject.transform.position);
           
            //�G�t�F�N�g�폜

            //�������폜
            Destroy(gameObject);
        }

        //�̗͂��c���Ă���ꍇ
        else
        {
            //�������Đ��B
            gameController.PlaySE("hit");
           
        }

    }

}

