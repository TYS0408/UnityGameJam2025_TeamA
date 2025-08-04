using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject hitEffectPrefab;              // �����G�t�F�N�g�v���n�u
    public int MAX_HIT_EFFECT = 100;                // �����G�t�F�N�g�ő吔
    List<GameObject> hitEffects;                    // �����G�t�F�N�g�ꗗ
    int hitIndex = 0;                               // ���Ɏg�������G�t�F�N�g�̈ʒu
    //�����G�t�F�N�g�Ǘ�
    public GameObject explosionEffectPrefab;        // �����G�t�F�N�g�v���n�u
    public int MAX_EXPLOSION_EFFECT = 100;          // �����G�t�F�N�g�ő吔
    List<GameObject> explosionEffects;              // �����G�t�F�N�g�ꗗ
    int explosionIndex = 0;                         // ���Ɏg�������G�t�F�N�g�̈ʒu
    void Start()
    {
        // �J�����̌��ʒu
        Vector3 hidePos = Camera.main.transform.position - Camera.main.transform.forward;

        // �����G�t�F�N�g���O�쐬
        hitEffects = new List<GameObject>();
        for (int i = 0; i < MAX_HIT_EFFECT; i++)
        {
            hitEffects.Add(Instantiate(hitEffectPrefab));
            hitEffects[i].transform.position = hidePos;
        }
        // �����G�t�F�N�g���O�쐬
        explosionEffects = new List<GameObject>();
        for (int i = 0; i < MAX_EXPLOSION_EFFECT; i++)
        {
            explosionEffects.Add(Instantiate(explosionEffectPrefab));
            explosionEffects[i].transform.position = hidePos;
        }

    }

    void Update()
    {
        
    }
    // �G�t�F�N�g�Đ�
    public void playEffect(string id, Vector3 pos)
    {
        GameObject effect = null;
        switch (id)
        {
            // �����G�t�F�N�g
            case "hit":
                effect = hitEffects[hitIndex];
                break;
            // �����G�t�F�N�g
            case "explosion":
                effect = explosionEffects[explosionIndex];
                break;
        }

        if (effect != null)
        {
            // �ʒu�ݒ�
            effect.transform.position = pos;
            // �A�j���[�V�����Đ�
            Animator animator = effect.GetComponent<Animator>();
            animator.SetTrigger("Play");
        }
    }


}
