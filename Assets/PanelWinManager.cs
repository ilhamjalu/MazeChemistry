using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PanelWinManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] TextMeshProUGUI timer;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI totalText;

    // Start is called before the first frame update
    void Start()
    {
        SetText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetText()
    {
        healthText.text = gameManager.healthAmount.ToString() + " / " + 3;
        totalText.text = gameManager.totalRightAnswer.ToString() + " / " + 10;
        timeText.text = timer.text;
    }
}
