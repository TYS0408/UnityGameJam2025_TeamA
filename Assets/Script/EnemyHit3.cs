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

    private void OnTriggerEnter(Collider other)
    {
        //�̗͂����炷
        HP--;

        //�̗͂��Ȃ��Ȃ����Ƃ�
            if(HP<=0)
        {
            //�����G�t�F�N�g�Đ�
            gameController.playEffect("explosion", gameObject.transform.position);
            //�������폜
            Destroy(gameObject);
        }
    }
}
