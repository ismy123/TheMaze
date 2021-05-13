using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthMng : MonoBehaviour
{
    Image guage;

    // Start is called before the first frame update
    void Start()
    {
        guage = GetComponent<Image>(); //이미지 컴포넌트 가져오기
    }

    public void SubHealth(float ratio)
    {
        guage.fillAmount = ratio; //게이지 감소
        if(guage.fillAmount <=0)//게이지가 0이면
        {
            SceneManager.LoadScene("Scene4_GameOver");
        }
    }
}
