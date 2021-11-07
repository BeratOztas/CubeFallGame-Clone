using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
   
     void Awake()
    {
    if(instance == null)
        {
            instance = this;
        }    
    }

    public void RestartGame()
    {
        Invoke("restartAfterTime", 2f);
    }
    void restartAfterTime()
    {
        StarScript.starCount = 0;
        SceneManager.LoadScene("GamePlay");
    }
}
