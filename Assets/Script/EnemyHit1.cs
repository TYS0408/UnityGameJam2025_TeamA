using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public int HP = 3;//Žc‚è‘Ì—Í
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    { 
            //‘Ì—Í‚ðŒ¸‚ç‚·
            HP--;
        //‘Ì—Í‚ª‚È‚­‚È‚Á‚½Žž
        if(HP <= 0)
        {
            //Ž©•ª‚ðíœ
            Destroy(gameObject);
        }
    }

}
