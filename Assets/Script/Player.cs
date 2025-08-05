using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    //プレイヤーのアニメーション。
    public Sprite spriteNomal;  //プレイヤーの通常スプライト
    public Sprite spriteDown;   //プレイヤーの下降スプライト
    public Sprite spriteUp;     //プレイヤーの上昇スプライト

    //弾の発射。
    public GameObject shotPrefab;  //弾のプレハブ
    public int maxShotCount = 20;  //事前に球を作成する数。
    public float shotSpeed = 30;   //弾が1秒間に進む距離。
    List<GameObject> shotList;     //弾キャッシュ（事前に作成する弾。）
    int nextShotIndex = 0;         //次に発射する弾キャッシュの位置。

    public GameObject shotFlash;   //弾のフラッシュエフェクト
    const int FLASH_VIEW_FRAME = 4; //発射効果を継続して表示するフレーム数。
    public int shotPerSec = 8;      //1秒間に発射する弾数。
    int shotFrame;                 //前の球を発射してからの経過フレーム数。

    // Start is called before the first frame update
    void Start()
    {
        //弾の発射。
        //カメラの後ろ位置。
        Vector3 hidePos = Camera.main.transform.position - Camera.main.transform.forward;

        //弾を事前に作成し、カメラの後ろに配置。
        shotList = new List<GameObject>();
        for(int i = 0; i < maxShotCount; i++)
        {
            //プレハブから球を生成。
            shotList.Add(Instantiate(shotPrefab));
            shotList[i].transform.position = hidePos;

            //リジットボディの加速度を指定。
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
        //移動量。
        Vector3 moveVec;

        //プレイヤー移動
        {
            //マウス座標取得。
            Vector3 pos = Input.mousePosition;
            //マウス座標をワールド座標に変換。
            pos.z = -Camera.main.transform.position.z;
            //スクリーン座標をワールド座標に転換。
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(pos);
            //現在位置からマウスワールド位置までの移動量。
            moveVec = (worldPos - transform.position) / 30;
            //徐々にマウス座標に近づくよう、移動量を分割して加算
            transform.position += moveVec;
        }

        //上下の移動量に応じてスプライトを切り替え。
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (Mathf.Abs(moveVec.y) < 0.05f)
        {
            //縦の移動量が0.05未満なら通常スプライト。
            spriteRenderer.sprite = spriteNomal;
        }
        else
        {
            if (moveVec.y < 0)
            {
                //縦の移動量がマイナスなら下降スプライト。
                spriteRenderer.sprite = spriteDown;
            }
            else
            {
                //縦の移動量がプラスなら上昇スプライト。
                spriteRenderer.sprite = spriteUp;
            }

        }

        //一秒間に発車する段数に応じて次の球を発射するまでのフレーム数。
        int shotInterval = 50 / shotPerSec;

        //弾発射。
        shotFrame++;
        if(shotFrame >=shotInterval)
        {
            //次の球待機を開始するため経過時間を初期化。
            shotFrame = 0;

            //弾をプレイヤー位置に移動。
            shotList[nextShotIndex].transform.position = transform.position;
            //次の弾の位置
            nextShotIndex++;
            if (nextShotIndex >= maxShotCount)
            {
                nextShotIndex = 0;
            }

            //弾のフラッシュエフェクトを生成。
            shotFlash.SetActive(true);
        }
        else if(shotFrame >=FLASH_VIEW_FRAME)
        {
            //発射効果の継続期間が過ぎたら発射効果を非表示。
            shotFlash.SetActive(false);
        }
    }
}
