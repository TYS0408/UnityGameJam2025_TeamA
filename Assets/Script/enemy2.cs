using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : MonoBehaviour
{
    //�����̎��
    public enum ENEMY_TYPE
    {
        LINE, //���i
        CURVE�@//�㉺�ɃJ�[�u
    }

    public ENEMY_TYPE type = ENEMY_TYPE.CURVE;
    public float speed = 3;//1�b�Ԃɐi�ދ���
    public float cycleCount = 2;//1�b�Ԃɉ��������
    public float curveLength = 3;�@//�J�[�u�̍ő勗��
     float cycleRadian =0;�@//Mathf.sin()�ɓn���p�x(���W�A��).
    float centerY;//�㉺�ړ��̒��Sy���W
    void Start()
    {
        //����y���W���uy���W�̒��S�v�Ƃ��ĕۑ�����
        centerY = transform.position.y;//�Q�[���J�n���Ɍ��݂�Y���W����ʒu�Ƃ��ċL�^
    }


    void Update()
    {
        
    }

    //�����������s�����߁AFixedUpdate()���]�b�g���g��
    private void FixedUpdate()
    {
        //���݂̍��W���擾
        Vector3 pos = transform.position;

        //�i�s�����Ɍ������Ē��i
        pos += -transform.right//���I�u�W�F�N�g�̉E�����x�N�g��(X������)
     * speed * Time.fixedDeltaTime;//�������X�V�Ԋu�̎���(�ʏ�0.02�b�j
        //�㉺�ɃJ�[�u
        if (type == ENEMY_TYPE.CURVE)
        {
            if(cycleCount > 0)
            {
                cycleRadian += (cycleCount * 2 * Mathf.PI) / 50; //�� 1�b�Ԃ̃��W�A���ω��ʁi1����=2�΃��W�A���j
                pos.y = Mathf.Sin(cycleRadian) * curveLength + centerY;
                //Mathf.Sin(cycleRadian)���T�C���͔g�ŏ㉺�^��
                //* curveLength���㉺�U�ꕝ����
                //+centerY����ʒu�𒆐S�ɏ㉺�ړ�
            }
        }
        //�V�������W�ɕύX
        transform.position = pos;
    }

}
