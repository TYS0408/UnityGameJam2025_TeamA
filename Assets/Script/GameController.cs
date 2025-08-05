using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //オーディオソース一覧
    public List<AudioSource> audioSrcList = new List<AudioSource>();
    public GameObject hitEffectPrefab;              // 命中エフェクトプレハブ
    public int MAX_HIT_EFFECT = 100;                // 命中エフェクト最大数
    List<GameObject> hitEffects;                    // 命中エフェクト一覧
    int hitIndex = 0;                               // 次に使う命中エフェクトの位置
    //爆発エフェクト管理
    public GameObject explosionEffectPrefab;        // 爆発エフェクトプレハブ
    public int MAX_EXPLOSION_EFFECT = 100;          // 爆発エフェクト最大数
    List<GameObject> explosionEffects;              // 爆発エフェクト一覧
    int explosionIndex = 0;                         // 次に使う爆発エフェクトの位置
    void Start()
    {
        audioSrcList.AddRange(GetComponentsInChildren<AudioSource>());

        // カメラの後ろ位置
        Vector3 hidePos = Camera.main.transform.position - Camera.main.transform.forward;

        // 命中エフェクト事前作成
        hitEffects = new List<GameObject>();
        for (int i = 0; i < MAX_HIT_EFFECT; i++)
        {
            hitEffects.Add(Instantiate(hitEffectPrefab));
            hitEffects[i].transform.position = hidePos;
        }
        // 爆発エフェクト事前作成
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
    // エフェクト再生
    public void playEffect(string id, Vector3 pos)
    {
        GameObject effect = null;
        switch (id)
        {
            // 命中エフェクト
            case "hit":
                effect = hitEffects[hitIndex];
                break;
            // 爆発エフェクト
            case "explosion":
                effect = explosionEffects[explosionIndex];
                break;
        }

        if (effect != null)
        {
            // 位置設定
            effect.transform.position = pos;
            // アニメーション再生
            Animator animator = effect.GetComponent<Animator>();
            animator.SetTrigger("Play");
        }
    }

    //効果音再生。
    public void PlaySE(string clipName)
    {
        //オーディオクリップ一覧から指定されたと一致するオーディオクリップを取得。
        AudioSource audioSrc = audioSrcList.Find(item => item.clip.name == clipName);
        //オーディオクリップが見つかった場合、再生する。
        if(audioSrc != null)
        {
            audioSrc.Play();
        }
    }
}
