using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
     if(other.collider.CompareTag("Player"))
     {
         Destroy(gameObject); //플레이어와 부딪히면 스스로 제거될 수 있도록
     }
    }
}
