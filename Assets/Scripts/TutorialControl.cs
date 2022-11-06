using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class TutorialControl : MonoBehaviour
{
    public Button SkipButton;

    public void SkipTutorial_1()
    {
        Debug.Log("QUIT");
        SceneManager.LoadScene("Challenge");
    }

}
