using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHit2 : MonoBehaviour
{
    public int HP = 3;//‘Ì—Í
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //‘Ì—Í‚ðŒ¸‚ç‚·
        HP--;
        //‘Ì—Í‚ª‚È‚­‚È‚Á‚½‚Æ‚«
        if( HP <= 0)
        {
            //Ž©•ª‚ðíœ
            Destroy(gameObject);
        }
    }
}
