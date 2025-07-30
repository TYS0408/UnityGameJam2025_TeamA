using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Sprite spriteNormal;     //プレイヤー通常スプライト
    public Sprite spriteDown;       //プレイヤー下降スプライト
    public Sprite spriteUp;         //プレイヤー上昇スプライト

    public GameObject shotPrefab;   //弾プレハブ
    public int maxShotCount = 20;   //事前に弾を生成する数。
    public float shotSpeed = 30;    //弾が1秒間に進む距離。
    List<GameObject> shotList;      //弾キャッシュ（事前に作成する弾)
    int nextShotIndex = 0;          //次に発射する弾キャッシュの位置。

    // Start is called before the first frame update
    void Start()
    {
        //カメラの後ろ位置
        Vector3 hidePos = Camera.main.transform.position - Camera.main.transform.forward;

        //弾を事前に作成し、カメラの後ろに配置。
        shotList = new List<GameObject>();
        for(int i = 0; i < maxShotCount; i++)
        {
            //プレイハブから球を生成。
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
        //移動量。
        Vector3 moveVec;
        //プレイヤー移動。
        {
            //マウス座標取得。
            Vector3 pos = Input.mousePosition;
            //マウス座標をスクリーン座標に変換。
            pos.z = -Camera.main.transform.position.z;
            //スクリーン座標をワールド座標に変換。
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(pos);
            //現在位置からマウスワールドまでの移動量。
            moveVec = (worldPos - transform.position) / 30;
            //徐々にマウス座標に近づくよう、移動量を分割して加算。
            transform.position += moveVec;

            //上下の移動量に応じてスプライトを切り替え。
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            if (Mathf.Abs(moveVec.y) < 0.05f)
            {
                //縦の移動量が0.05未満なら通常スプライト。
                spriteRenderer.sprite = spriteNormal;
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
            //弾をプレイヤー位置に移動。
            shotList[nextShotIndex].transform.position = transform.position;
            //次の球位置
            nextShotIndex++;
            if(nextShotIndex >= maxShotCount)
            {
                nextShotIndex = 0;
            }
            //弾移動
            for(int i = 0; i< maxShotCount; i++)
            {
                shotList[i].transform.position += transform.right * shotSpeed * Time.fixedDeltaTime;
            }

        }
    }
}
