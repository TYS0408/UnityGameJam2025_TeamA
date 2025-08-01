using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //�ړ��ʁB
        Vector3 moveVec;

        //�v���C���[�ړ�
        {
            //�}�E�X���W�擾�B
            Vector3 pos = Input.mousePosition;
            //�}�E�X���W�����[���h���W�ɕϊ��B
            pos.z = -Camera.main.transform.position.z;
            //�X�N���[�����W�����[���h���W�ɓ]���B
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(pos);
            //���݈ʒu����}�E�X���[���h�ʒu�܂ł̈ړ��ʁB
            moveVec = (worldPos - transform.position) / 30;
            //���X�Ƀ}�E�X���W�ɋ߂Â��悤�A�ړ��ʂ𕪊����ĉ��Z
            transform.position += moveVec;
        }
    }
}
