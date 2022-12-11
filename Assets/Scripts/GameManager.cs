using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerHealthText;
    [SerializeField] TextMeshProUGUI answeredQuestionText;
    [SerializeField] public int healthAmount;
    [SerializeField] public int totalRightAnswer;
    [SerializeField] GameObject soal;
    [SerializeField] GameObject pembahasan;
    [SerializeField] GameObject stoppedScene;
    [SerializeField] ButtonScript buttonScript;
    [SerializeField] SoalManager soalManager;
    [SerializeField] Timer timer;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject losePanel;
    [SerializeField] AudioSource wrongAudio;
    [SerializeField] AudioSource correctAudio;
    [SerializeField] AudioSource buttonAudio;
    [SerializeField] public List<int> soalDone = new List<int>();
    [SerializeField] JoystickPlayerExample playerScript;
    

    // Start is called before the first frame update
    void Start()
    {
        playerScript.canWalk = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.TimeUp() || healthAmount <= 0)
        {
            GameLose();
            playerScript.canWalk = false;
        }
    }

    public void SoundButton()
    {
        buttonAudio.Play();
    }

    void GameLose()
    {
        Debug.Log("GAME LOSE");
        losePanel.SetActive(true);
    }

    void MinimumValue()
    {
        if(healthAmount < 0 || totalRightAnswer < 0)
        {
            totalRightAnswer = 0;
            healthAmount = 0;

            answeredQuestionText.text = totalRightAnswer.ToString();
            playerHealthText.text = healthAmount.ToString();
        }
    }

    public void CheckAnswer(bool isCorrect)
    {
        if (isCorrect)
        {
            correctAudio.Play();

            totalRightAnswer += 1;
            answeredQuestionText.text = totalRightAnswer.ToString();
            soal.SetActive(false);
        }
        else
        {
            healthAmount -= 1;
            playerHealthText.text = healthAmount.ToString();
            soal.SetActive(false);
            pembahasan.SetActive(true);

            WrongAnswer();
        }

        MinimumValue();
    }

    public void AddDoneQuestion(int index)
    {
        soalDone.Add(index);
    }

    public void ActivateLamp(int indexQuestion)
    {
        foreach (GameObject lamp in GameObject.FindGameObjectsWithTag("Lamp"))
        {
            if(lamp.name == indexQuestion.ToString())
            {
                lamp.transform.GetChild(0).gameObject.SetActive(true);
            }
        }

    }

    public void GameDoneCheck()
    {
        if(totalRightAnswer >= 5)
        {
            Debug.Log("SELESAI");
            winPanel.SetActive(true);

            if(SceneManager.GetActiveScene().name == "Level_1")
            {
                PlayerPrefs.SetInt("Level", 2);
            }
            else
            {
                PlayerPrefs.SetInt("Level", 1);
            }

            timer.runTimer = false;
        }
        else
        {
            stoppedScene.SetActive(true);
        }
    }

    void WrongAnswer()
    {
        wrongAudio.Play();
        soalManager.PembahasanText();
    }
}
