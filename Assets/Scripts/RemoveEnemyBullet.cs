/*
적 발사체 제거
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveEnemyBullet : MonoBehaviour
{
    public GameObject sparkEffect;
    public AudioClip shotSound; // 총알 맞은 사운드 클립
    AudioSource ads; //AudioSource 컴포넌트

    private void Start() 
    {
        ads = GetComponent<AudioSource>(); //AudioSource 컴포넌트 가져오기
    }

    void OnCollisionEnter(Collision coll)
    {
        if(coll.collider.tag=="ENEMYBULLET")
        {
            ads.PlayOneShot(shotSound); //총소리 재생
            GameObject spark = Instantiate(sparkEffect); //충돌 효과 생성
            spark.transform.position = coll.transform.position;
            spark.transform.localScale *= 0.5f; //이펙트 절반 크기
            Destroy(spark,1); //1초후 충돌효과 제거
            Destroy(coll.gameObject); //발사체 제거
            
        }
    }
}
