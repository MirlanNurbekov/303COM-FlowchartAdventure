using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public ChallengeManager challengeManager;
    
    public Color startColor;

    private void Start()
    {
        startColor=GetComponent<Image>().color = Color.white;
    }

    public void Answer()
    {
        if(isCorrect)
        {
            //GetComponent<Image>().color = Color.green;
            //Debug.Log("Correct Answer");
            challengeManager.correct();
            Invoke("SetBackToNormal",0.1f);

        }
        else
        {
            //GetComponent<Image>().color = Color.red;
            //Debug.Log("Wrong");
            challengeManager.wrong();
            Invoke("SetBackToNormal",0.1f);

            //GetComponent<Image>().color = Color.white;

        }
    }

    public void SetBackToNormal(){
        GetComponent<Image>().color = Color.white;
    }
    

}
