using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    //StartTutorial_1 function is used to start the lesson to learn flowchart
    public TMP_InputField playerNameInput;
    public Button playButton;
    public TextMeshProUGUI welcomeText;
    string textSentence;
    public void StartTutorial_1()
    {
        SceneManager.LoadScene("LearningStage1");
    }
        public void StartChallenge()
    {
        SceneManager.LoadScene("Challenge");
    }

        public void StartSettings()
    {
        SceneManager.LoadScene("Settings");
    }

        public void PlayButton()
    {
        Debug.Log("Button is clicked");
        GameInstance.instance.playerName = playerNameInput.text;
        welcomeText.text = "Hello and Welcome " +  GameInstance.instance.playerName +", pick the gamemode you want to play ";

    }

    void Update(){
        
        if(playerNameInput.text == ""){
            playButton.interactable = false;
        }else{
            playButton.interactable = true;
        }
    }
    //QuitTheProgram is used to exit the project
    public void QuitTheProgram()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }


    
}
