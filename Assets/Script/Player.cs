using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Sprite spriteNomal;  //�v���C���[�̒ʏ�X�v���C�g
    public Sprite spriteDown;   //�v���C���[�̉��~�X�v���C�g
    public Sprite spriteUp;     //�v���C���[�̏㏸�X�v���C�g

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

        //�㉺�̈ړ��ʂɉ����ăX�v���C�g��؂�ւ��B
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (Mathf.Abs(moveVec.y) < 0.05f)
        {
            //�c�̈ړ��ʂ�0.05�����Ȃ�ʏ�X�v���C�g�B
            spriteRenderer.sprite = spriteNomal;
        }
        else
        {
            if (moveVec.y < 0)
            {
                //�c�̈ړ��ʂ��}�C�i�X�Ȃ牺�~�X�v���C�g�B
                spriteRenderer.sprite = spriteDown;
            }
            else
            {
                //�c�̈ړ��ʂ��v���X�Ȃ�㏸�X�v���C�g�B
                spriteRenderer.sprite = spriteUp;
            }

        }
        
    }
}
