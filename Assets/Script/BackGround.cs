using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float speed = 0.01f; // �w�i�̈ړ����x
    public float scrollWidth = 5.44f; // �X�N���[�����镝

    // Start is called before the first frame update
    void Start()
    {
        //�����̃X�P�[���ɍ��킹�āu���[�v�̕��v���v�Z�B
        scrollWidth *= transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�������Z���ɏ����B
    void FixedUpdate()
    {
        //�X�N���[���B
        Vector3 pos = transform.position;
        pos.x -= speed;
        //���[�v�����z���Ĉړ������ꍇ�B
        if (-scrollWidth > pos.x)
        {
            //���[�v�������ɖ߂��B
            pos.x += scrollWidth;
        }
        transform.position = pos;

    }
}
