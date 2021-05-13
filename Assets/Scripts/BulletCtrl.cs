using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    public float speed = 1000.0f; //총알 발사 속도 = force

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        //오브젝트의 Y축(up)방향으로 힘을 가함
        rb.AddForce(transform.up*speed);//transform.up = 로컬좌표계의 위쪽방향을 의미 오브젝트가 어느쪽을 바라보고 있더라도 위쪽으로 발사
    }
}
