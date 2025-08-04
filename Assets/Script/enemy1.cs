using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class enemy1 : MonoBehaviour
{
    //�����̎��
    public enum ENEMY_TYPE
    {
        LINE,
        CURVE
    }

    //�����̎��
    public ENEMY_TYPE type = ENEMY_TYPE.CURVE;

    

    public float speed = 20; //1�b�Ԃɐi�ދ���
    //�����X�V���ɏ���
    private void FixedUpdate()
    {
        //���݂̍��W���擾
        Vector3 pos = transform.position;

        //�i�s�����Ɍ������Ē��i
        pos += -transform.right * speed * Time.fixedDeltaTime;
        //�㉺�ɃJ�[�u
        if(type == ENEMY_TYPE.CURVE)
        {
            if(cycleCount > 0)
            {
                cycleRadian += (cycleCount * 2 * Mathf.PI) / 50;
                pos.y = Mathf.Sin(cycleRadian) * curveLength + centerY;
            }
        }

        //�V�������W�ɕύX
        transform.position = pos;
    }

    public float cycleCount = 1;//1�b�Ԃɉ��������
    public float curveLength = 2;//�J�[�u�̍ő勗��
    float cycleRadian = 0;//�T�C���ɓn���l
    float centerY; //Y���W�̒��S
    void Start()
    {
        //����y���W���uy���W�̒��S�v�Ƃ��ĕۑ�����
        centerY = transform.position.y;
    }


    void Update()
    {
    }
}
