using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class ChallengeManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public TextMeshProUGUI QuestionTxt;
    public TextMeshProUGUI ScoreTxt;
    public TextMeshProUGUI LifesCounterTxt;

    public int TotalQuestions = 0;
    public int ScoreCount;

    //for switching between pannels
    public GameObject EzQuestionsPannel;
    public GameObject EndOfChallengePannel;

    //life count
    public int lifesLeft;

    //for ez question counter
    public int EzQuestionsCounter;

    // image for question
    public Image questionImage;
    public TextMeshProUGUI feedback;

    public static ChallengeManager instance;

    void Awake(){
        instance = this;
    }
    private void Start()
    {
        TotalQuestions = QnA.Count;
        //EndOfChallengePannel.SetActive(false);
        generateQuestion();
    }

    //END of the challenge session
    public void GameOver()
    {
        EzQuestionsPannel.SetActive(false);
        EndOfChallengePannel.SetActive(true);
        ScoreTxt.text = ScoreCount+"/"+TotalQuestions;
        
    }

    //To reload the challenge
    public void ReloadTheChallenge()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void correct()
    {
        feedback.text = "<color=green>Good job keep it up</color>";

        ScoreCalculator();
        QnA.RemoveAt(currentQuestion);
        QuestionReduction();
        ChekGameStatus();
        generateQuestion();
    }

    public void wrong()
    {
        feedback.text = "<color=red>"+QnA[currentQuestion].feedback+"</color>";
        //when answer was wrong
        QnA.RemoveAt(currentQuestion);
        LostLife();
        QuestionReduction();
        ChekGameStatus();
        generateQuestion();
        LifesCounterTxt.text = " "+lifesLeft;
    }


    public void SetAnswers()
    {
        for(int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text=QnA[currentQuestion].Answers[i];

            if(QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    public void generateQuestion()
    {
        if(QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[currentQuestion].Question;
            if(QnA[currentQuestion].ImageSprite == null){
                questionImage.gameObject.SetActive(false);
            }else{
                    questionImage.gameObject.SetActive(true);
                    questionImage.sprite = QnA[currentQuestion].ImageSprite;
            }
            SetAnswers();
        }
        else
        {
            Debug.Log("Out of questions");
            GameOver();
        }
    }

    public void LostLife()
    {
        lifesLeft-=1;
    }

    public void QuestionReduction()
    {
         EzQuestionsCounter-=1;
         Debug.Log("Q left" + EzQuestionsCounter);
    }

    public void ChekGameStatus()
    {
        if(lifesLeft==0 || EzQuestionsCounter==0)
        {
            GameOver();
        }
    }

    //score counter
    public void ScoreCalculator()
    {
        ScoreCount +=1;
    }
}
