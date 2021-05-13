/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath2 : MonoBehaviour
{
    public GameObject expEffect; // 폭발 효과 프리팹
    public AudioClip expSound; // 폴발 사운드 클립
    public int deathNum = 3; // 사망 피격 회수

    int hitCount = 0; //총알에 맞은 횟수. private 변수
    AudioSource ads; //AudioSource 컴포넌트



    void OnCollisionEnter(Collision coll)
    {
        if(coll.collider.CompareTag("BULLET")) //충돌한 오브젝트의 태그 비교
        {
            if(++hitCount == deathNum)
            {
                GetComponent<EnemyCtrl>().enabled = false; //EnemyCtrl 비활성화
                ExpEnemy(); // 폭발 처리 함수 호출
            }
        }
    }

    void ExpEnemy()
    {
        GameObject effect = Instantiate(expEffect); //폭발 효과 생성
        effect.transform.position = transform.position; //폭발 효과 위치 지정
        Destroy(effect,2.0f); //2초후 자동제거
        ads.PlayOneShot(expSound); //폭발음 재생
    }
}
*/