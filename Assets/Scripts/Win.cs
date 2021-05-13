using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
        {
            if(other.GetComponent<Collider>().tag == "Player")
            {
                SceneManager.LoadScene("Scene5_GameWin");
            }
        }
}
