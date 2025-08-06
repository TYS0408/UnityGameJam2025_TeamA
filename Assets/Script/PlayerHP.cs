using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField, Header("HPアイコン")]
    private GameObject playerIcon;//HPアイコンのプレハブ

    private Player player;//プレイヤーのスクリプトを取得
    private int beforeHP;//前回のHPを記録
    void Start()
    {
        //プレイヤーのスクリプトを探して取得
        player = FindObjectOfType<Player>();
        beforeHP = player.GetHP();
        CreateHPIcon();

    }




    private void CreateHPIcon()
    {
        //プレイヤーの数だけアイコン作成
        for (int i = 0; i < player.GetHP(); i++)
        {
            GameObject playerHPobj = Instantiate(playerIcon);
            playerHPobj.transform.SetParent(transform);//親(HPオブジェクト)に設定

        }
    }
    void Update()
    {
        showHPIcon();//HPの変化をチェック

    }

    private void showHPIcon()
    {
        if (beforeHP == player.GetHP()) return;

        //全てのHPアイコンを取得
        Image[] icons = transform.GetComponentsInChildren<Image>();

        //現在のHP以下のアイコンのみ表示、それ以外は非表示にする
        for (int i = 0; i < icons.Length; i++)
        {
            icons[i].gameObject.SetActive(i < player.GetHP());
        }

        //HPの変更を記録
        beforeHP = player.GetHP();
    }
}

