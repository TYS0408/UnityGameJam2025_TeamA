using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    // Start is called before the first frame update
    public int HP = 3;//�c��̗�
    GameController gameController; //�Q�[���Ǘ��I�u�W�F�N�g
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
        //�^�O�������ꍇ�͏Փ˂����Ȃ��B
        if(tag == collider.gameObject.tag)
        {
            return;
        }

        //�̗͂����炷
        HP--;
        //�̗͂��Ȃ��Ȃ�����
        if (HP <= 0)
        {
            //�����G�t�F�N�g�Đ�
            gameController.playEffect("explosion", gameObject.transform.position);
            //�G�t�F�N�g�폜

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


