using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    //�v���C���[�̃A�j���[�V�����B
    public Sprite spriteNomal;  //�v���C���[�̒ʏ�X�v���C�g
    public Sprite spriteDown;   //�v���C���[�̉��~�X�v���C�g
    public Sprite spriteUp;     //�v���C���[�̏㏸�X�v���C�g

    //�e�̔��ˁB
    public GameObject shotPrefab;  //�e�̃v���n�u
    public int maxShotCount = 20;  //���O�ɋ����쐬���鐔�B
    public float shotSpeed = 30;   //�e��1�b�Ԃɐi�ދ����B
    List<GameObject> shotList;     //�e�L���b�V���i���O�ɍ쐬����e�B�j
    int nextShotIndex = 0;         //���ɔ��˂���e�L���b�V���̈ʒu�B

    public GameObject shotFlash;   //�e�̃t���b�V���G�t�F�N�g
    const int FLASH_VIEW_FRAME = 4; //���ˌ��ʂ��p�����ĕ\������t���[�����B
    public int shotPerSec = 8;      //1�b�Ԃɔ��˂���e���B
    int shotFrame;                 //�O�̋��𔭎˂��Ă���̌o�߃t���[�����B

    // Start is called before the first frame update
    void Start()
    {
        //�e�̔��ˁB
        //�J�����̌��ʒu�B
        Vector3 hidePos = Camera.main.transform.position - Camera.main.transform.forward;

        //�e�����O�ɍ쐬���A�J�����̌��ɔz�u�B
        shotList = new List<GameObject>();
        for(int i = 0; i < maxShotCount; i++)
        {
            //�v���n�u���狅�𐶐��B
            shotList.Add(Instantiate(shotPrefab));
            shotList[i].transform.position = hidePos;

            //���W�b�g�{�f�B�̉����x���w��B
            Rigidbody rb = shotList[i].GetComponent<Rigidbody>();
            rb.velocity = transform.right * shotSpeed;
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

        //��b�Ԃɔ��Ԃ���i���ɉ����Ď��̋��𔭎˂���܂ł̃t���[�����B
        int shotInterval = 50 / shotPerSec;

        //�e���ˁB
        shotFrame++;
        if(shotFrame >=shotInterval)
        {
            //���̋��ҋ@���J�n���邽�ߌo�ߎ��Ԃ��������B
            shotFrame = 0;

            //�e���v���C���[�ʒu�Ɉړ��B
            shotList[nextShotIndex].transform.position = transform.position;
            //���̒e�̈ʒu
            nextShotIndex++;
            if (nextShotIndex >= maxShotCount)
            {
                nextShotIndex = 0;
            }

            //�e�̃t���b�V���G�t�F�N�g�𐶐��B
            shotFlash.SetActive(true);
        }
        else if(shotFrame >=FLASH_VIEW_FRAME)
        {
            //���ˌ��ʂ̌p�����Ԃ��߂����甭�ˌ��ʂ��\���B
            shotFlash.SetActive(false);
        }
    }
}
