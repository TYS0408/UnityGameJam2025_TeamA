using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit3 : MonoBehaviour
{
    public int HP = 3;
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
            if(HP<=0)
        {
            Destroy(gameObject);
        }
    }
}
