using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy3 : MonoBehaviour
{
    public float speed = 40;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //���݂̍��W���擾
        Vector3 pos = transform.position;

        //�i�s�����Ɍ������Ē��i
        pos += -transform.right * speed * Time.fixedDeltaTime;

        //�V�������W�ɓo�^
        transform.position = pos;
    }
}
