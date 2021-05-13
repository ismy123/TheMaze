using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath2 : MonoBehaviour
{
    public GameObject expEffect; // 폭발 효과 프리팹
    public AudioClip expSound; // 폴발 사운드 클립
    public AudioClip firstaidSound; //firstaid 먹었을 때 나올 사운드
    public int deathNum = 10; // 사망 피격 회수
    public HealthMng hm;
    public GameObject FirstAid; //firstaid

    int hitCount = 0; //총알에 맞은 횟수. private 변수
    AudioSource ads; //AudioSource 컴포넌트

    // Start is called before the first frame update
    void Start()
    {
        ads = GetComponent<AudioSource>(); //AudioSource 컴포넌트 가져오기
    }

    void OnCollisionEnter(Collision coll)
    {
        if(coll.collider.CompareTag("ENEMYBULLET")) //충돌한 오브젝트의 태그 비교
        {
            if(++hitCount == deathNum)
            {
                GetComponent<PlayerCtrl6>().enabled = false; //PlayerCtrl6 비활성화
                //GetComponentInChildren<FireCtrl3>().enabled = false;//FireCtrl3 비활성화
                ExpPlayer(); // 폭발 처리 함수 호출
            }
            float amount = 1 - ((float)hitCount / deathNum);
            hm.SubHealth(amount);
        }

        if(coll.collider.CompareTag("FIRSTAID"))
        {
            ads.PlayOneShot(firstaidSound); //효과음 재생
            float firstaid = 1 - ((float)hitCount / deathNum) + 0.2f; // 사용자 hp 증가
            hm.SubHealth(firstaid);
        }

        
    }

    void ExpPlayer()
    {
        GameObject effect = Instantiate(expEffect); //폭발 효과 생성
        effect.transform.position = transform.position; //폭발 효과 위치 지정
        Destroy(effect,2.0f); //2초후 자동제거
        ads.PlayOneShot(expSound); //폭발음 재생
    }
}
