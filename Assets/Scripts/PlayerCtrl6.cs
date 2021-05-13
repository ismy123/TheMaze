/*
    플레이어 이동,회전 스크립트
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl6 : MonoBehaviour
{
    public float moveSpeed = 10.0f;//이동속도
    public float rotSpeed = 100.0f;//회전속도
    public float force = 300; //가해지는 힘의 크기

    Vector3 AXIS_X = new Vector3(1,0,0); //X축
    Vector3 AXIS_Y = new Vector3(0,1,0); //Y축
    Vector3 AXIS_Z = new Vector3(0,0,1); //Z축

    Transform tr;
    Rigidbody rb;

    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move() //평면 이동
    {
        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        
        else if (Input.GetKey("s"))
        {
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey("a"))
        {
            transform.Rotate(Vector3.up,-rotSpeed * Time.deltaTime);
        }
        else if (Input.GetKey("d"))
        {
            transform.Rotate(Vector3.up, rotSpeed * Time.deltaTime);
        }
    }
}
