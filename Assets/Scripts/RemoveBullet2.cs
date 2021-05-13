/*
    충돌 이펙트 스크립트
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet2 : MonoBehaviour
{
    public GameObject sparkEffect; // 충돌 효과 프리팹
    public AudioClip shotSound; // 총알 맞은 사운드 클립
    AudioSource ads; //AudioSource 컴포넌트

    private void Start() 
    {
        ads = GetComponent<AudioSource>(); //AudioSource 컴포넌트 가져오기
    }

    void OnCollisionEnter(Collision coll)
    {
        //충돌한 게임 오브젝트의 태그값 비교
        if(coll.collider.tag == "BULLET")
        {
            ads.PlayOneShot(shotSound); //총소리 재생
            GameObject spark = Instantiate(sparkEffect); // 충돌 효과 생성
            spark.transform.position = coll.transform.position; // 충돌 위치 지정
            Destroy(spark,1); //1초 후 충돌 효과 제거
            
            //충돌한 게임 오브젝트 삭제
            Destroy(coll.gameObject);
        }
    }
}
