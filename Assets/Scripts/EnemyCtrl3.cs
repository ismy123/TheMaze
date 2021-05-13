/*
추적 & 순찰 & 공격 타입
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl3 : MonoBehaviour
{
    Animator anim;
    public Transform playerTr; //주인공 위치
    public GameObject bullet; // 총알 프리팹
    public EnemyHealthMng hm; //enemy의 guage
    public int deathNum = 3;
    public GameObject expEffect; // 폭발 효과 프리팹
    public AudioClip expSound; // 폴발 사운드 클립

    public float attackDist = 35; //공격거리
    public float shotInterval = 2;

    int hitCount = 0; //총알에 맞은 횟수. private 변수
    int nextIndex = 0; // 다음 순찰지점 인덱스
    float shotTime = 1; //발사 경과 시간

    AudioSource ads; //AudioSource 컴포넌트
    Renderer render; //Renderer 컴포넌트 변수 -> 색깔을 바꾸기 위해 사용

    bool attack;

    // Start is called before the first frame update
    void Start()
    {
        attack = false;
        ads = GetComponent<AudioSource>(); //AudioSource 컴포넌트 가져오기
        render = GetComponent<Renderer>(); //Renderer 컴포넌트 가져오기 
        render.material.color = Color.yellow; // 색상을 yellow로 변경
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = (playerTr.position - transform.position).magnitude; // 플레이어와의 거리 계산
        if(dist < attackDist)
        {
            shotTime += Time.deltaTime;
            if(shotTime>shotInterval)
            {
                if(attack = true)
                {
                    Attack(); //주인공 공격
                    shotTime = 0;
                }
            }
        }
    }

    void Attack()
    {
        //사격 방향 계산
        Vector3 fireDir = (playerTr.position - transform.position).normalized;//목표지점-시작지점 => 벡터가 게산이 됌(순서가 바뀌면 안됌)
        //총알 프리팹 생성
        GameObject obj = Instantiate(bullet);
        obj.transform.position = transform.position;
        obj.GetComponent<Rigidbody>().AddForce(fireDir*600);

        Destroy(obj,5); //5초후 자동 소멸

        if(hitCount == deathNum)
            {
                Destroy(obj,0); //다 삭제
            }
    }

    void OnCollisionEnter(Collision coll)
    {
        if(coll.collider.CompareTag("BULLET")) //충돌한 오브젝트의 태그 비교
        {
            if(++hitCount == deathNum)
            {
                attack = false;//Enemy 이동 비활성화
                ExpEnemy(); // 폭발 처리 함수 호출
            }
            float amount = 1 - ((float)hitCount / deathNum);
            hm.SubHealth(amount);
        }
    }

    void ExpEnemy()
    {
        anim.GetComponent<Animator>().enabled = false;
        GetComponent<Renderer>().material.color = Color.black; //색상을 black 으로 변경
        GameObject effect = Instantiate(expEffect); //폭발 효과 생성
        effect.transform.position = transform.position; //폭발 효과 위치 지정
        Destroy(effect,2.0f); //2초후 자동제거
        ads.PlayOneShot(expSound); //폭발음 재생
    }
}
