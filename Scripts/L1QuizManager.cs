using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class L1QuizManager : MonoBehaviour
{
    public GameObject questionCanvas;
    
    // public GameObject thirdPersonCanvas;
    // public GameObject aimCanvas;
    // public GameObject thirdPersonCam;
    // public GameObject aimCam;
    public List<L1QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public TextMeshProUGUI QuestionText;

    // private bool playerIsAnswering = false;
     private int currentQuestionIndex = -1;


    private void Start()
    {

        StartQuestionRound();
    }

    public void StartQuestionRound()
    {
        // thirdPersonCanvas.SetActive(false);
        // aimCanvas.SetActive(false);
        // thirdPersonCam.SetActive(false);
        // aimCam.SetActive(false);

        // Cursor.lockState = CursorLockMode.None;
        // Cursor.visible = true;
        // currentQuestion = Random.Range(0,QnA.Count);

        currentQuestionIndex++;
        if (currentQuestionIndex < QnA.Count)
        {
            QuestionText.text = QnA[currentQuestionIndex].Question;
            SetAnswers();
        }
        // else
        // {
        //     questionCanvas.SetActive(false);

        //     // Reset the cursor to locked and invisible
        //     // Cursor.lockState = CursorLockMode.Locked;
        //     // Cursor.visible = false;
        // }
    }


    public void StopQuestionRound()
    {
        
        // Deactivate the question canvas when the question round is over

        Debug.Log("StopQuestionRound called.");
        // Deactivate the question canvas when the question round is over
        questionCanvas.SetActive(false);

        // Activate the other canvases
        // thirdPersonCanvas.SetActive(true);
        // aimCanvas.SetActive(true);
        // thirdPersonCam.SetActive(true);
        // aimCam.SetActive(true);

        // Restore the original cursor state and visibility

        // Cursor.lockState= CursorLockMode.Locked;
        // Cursor.visible = false;

        


    }

    public void correct()
    {
        // Stop the current question round
        Debug.Log("Correct method called.");
        StopQuestionRound();
        
    }

   void SetAnswers()
{
    for (int i = 0; i < options.Length; i++)
    {
        options[i].GetComponent<L1AnswerScript>().isCorrect = false;

        // Update TMP text component
        TextMeshProUGUI optionText = options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        optionText.text = QnA[currentQuestionIndex].Answers[i];

        if (QnA[currentQuestionIndex].CorrectAnswer == i + 1)
        {
            options[i].GetComponent<L1AnswerScript>().isCorrect = true;
        }
    }
}
}