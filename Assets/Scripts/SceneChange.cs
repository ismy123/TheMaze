/*
    씬을 변경할 수 있도록 해주는 스크립트 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void GoToScene1()//첫번째 씬으로 이동
    {
        SceneManager.LoadScene("Scene1_Start");
    }

    public void GoToScene2()//두번째 씬으로 이동
    {
        SceneManager.LoadScene("Scene2_Tutorial");
    }

    public void GoToScene3()//세번째 씬으로 이동
    {
        SceneManager.LoadScene("Scene3_GameScene");
    }
}
