using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField, Header("HP�A�C�R��")]
    private GameObject playerIcon;//HP�A�C�R���̃v���n�u

    private Player player;//�v���C���[�̃X�N���v�g���擾
    private int beforeHP;//�O���HP���L�^
    void Start()
    {
        //�v���C���[�̃X�N���v�g��T���Ď擾
        player = FindObjectOfType<Player>();
        beforeHP = player.GetHP();
        CreateHPIcon();

    }




    private void CreateHPIcon()
    {
        //�v���C���[�̐������A�C�R���쐬
        for (int i = 0; i < player.GetHP(); i++)
        {
            GameObject playerHPobj = Instantiate(playerIcon);
            playerHPobj.transform.SetParent(transform);//�e(HP�I�u�W�F�N�g)�ɐݒ�

        }
    }
    void Update()
    {
        showHPIcon();//HP�̕ω����`�F�b�N

    }

    private void showHPIcon()
    {
        if (beforeHP == player.GetHP()) return;

        //�S�Ă�HP�A�C�R�����擾
        Image[] icons = transform.GetComponentsInChildren<Image>();

        //���݂�HP�ȉ��̃A�C�R���̂ݕ\���A����ȊO�͔�\���ɂ���
        for (int i = 0; i < icons.Length; i++)
        {
            icons[i].gameObject.SetActive(i < player.GetHP());
        }

        //HP�̕ύX���L�^
        beforeHP = player.GetHP();
    }
}

