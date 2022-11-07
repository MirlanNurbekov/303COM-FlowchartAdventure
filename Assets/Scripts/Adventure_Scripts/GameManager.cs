using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int currentSolved;
    public int solved;
    public string sceneName;
    public static GameManager instance;

    void Awake(){
        instance = this;
    }

    public void ChangeScene(){
        if(currentSolved==solved){
            SceneManager.LoadScene(sceneName);
        }

    }



}
