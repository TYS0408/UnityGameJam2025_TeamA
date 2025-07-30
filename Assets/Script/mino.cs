using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Sprite spriteNormal;     //�v���C���[�ʏ�X�v���C�g
    public Sprite spriteDown;       //�v���C���[���~�X�v���C�g
    public Sprite spriteUp;         //�v���C���[�㏸�X�v���C�g

    public GameObject shotPrefab;   //�e�v���n�u
    public int maxShotCount = 20;   //���O�ɒe�𐶐����鐔�B
    public float shotSpeed = 30;    //�e��1�b�Ԃɐi�ދ����B
    List<GameObject> shotList;      //�e�L���b�V���i���O�ɍ쐬����e)
    int nextShotIndex = 0;          //���ɔ��˂���e�L���b�V���̈ʒu�B

    // Start is called before the first frame update
    void Start()
    {
        //�J�����̌��ʒu
        Vector3 hidePos = Camera.main.transform.position - Camera.main.transform.forward;

        //�e�����O�ɍ쐬���A�J�����̌��ɔz�u�B
        shotList = new List<GameObject>();
        for(int i = 0; i < maxShotCount; i++)
        {
            //�v���C�n�u���狅�𐶐��B
            shotList.Add(Instantiate(shotPrefab));
            shotList[i].transform.position = hidePos;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        //�ړ��ʁB
        Vector3 moveVec;
        //�v���C���[�ړ��B
        {
            //�}�E�X���W�擾�B
            Vector3 pos = Input.mousePosition;
            //�}�E�X���W���X�N���[�����W�ɕϊ��B
            pos.z = -Camera.main.transform.position.z;
            //�X�N���[�����W�����[���h���W�ɕϊ��B
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(pos);
            //���݈ʒu����}�E�X���[���h�܂ł̈ړ��ʁB
            moveVec = (worldPos - transform.position) / 30;
            //���X�Ƀ}�E�X���W�ɋ߂Â��悤�A�ړ��ʂ𕪊����ĉ��Z�B
            transform.position += moveVec;

            //�㉺�̈ړ��ʂɉ����ăX�v���C�g��؂�ւ��B
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            if (Mathf.Abs(moveVec.y) < 0.05f)
            {
                //�c�̈ړ��ʂ�0.05�����Ȃ�ʏ�X�v���C�g�B
                spriteRenderer.sprite = spriteNormal;
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
            //�e���v���C���[�ʒu�Ɉړ��B
            shotList[nextShotIndex].transform.position = transform.position;
            //���̋��ʒu
            nextShotIndex++;
            if(nextShotIndex >= maxShotCount)
            {
                nextShotIndex = 0;
            }
            //�e�ړ�
            for(int i = 0; i< maxShotCount; i++)
            {
                shotList[i].transform.position += transform.right * shotSpeed * Time.fixedDeltaTime;
            }

        }
    }
}
