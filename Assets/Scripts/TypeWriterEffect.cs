using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TypeWriterEffect : MonoBehaviour
{
    public float delay = 0.15f;
    public string fullText;
    private string currentText = "";
    public GameObject Btn_Start;
    
    // Start is called before the first frame update
    void Start()
    {
        Btn_Start.SetActive(false);
        StartCoroutine (ShowText());
    }

    IEnumerator ShowText()
    {
        GetComponent<AudioSource>().Play(); // 글자가 보여지기 시작할때 효과음 실행
        for (int i = 0; i < fullText.Length; i++) 
        {
            currentText = fullText.Substring(0,i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay); // 한글자씩 쳐지고 멈추고를 반복하여 텍스트가 쳐지는 것 같이 보여짐
        }
        GetComponent<AudioSource>().Stop(); // 글자가 fullText면 효과음 실행 멈춤
        Btn_Start.SetActive(true);
    }

}
