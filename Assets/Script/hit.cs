using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : MonoBehaviour
{
    public int energy = 3;      //�c��̗́B

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        void OnTriggeerEnger2D(Collider2D collider)
        {
            //�̗͂����炷�B
            energy--;
            //�̗͂��O�ɂȂ�����I�u�W�F�N�g���폜����B
            if(energy<=0)
            {
                Destroy(gameObject);
            }
        }
    }
}
