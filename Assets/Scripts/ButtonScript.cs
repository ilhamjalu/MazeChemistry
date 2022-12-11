using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] GameObject soal;
    [SerializeField] SoalManager soalManager;
    public int indexSoal;

    public void ShowSoal()
    {
        soalManager.SoalText(indexSoal);
    }

    public void ClosePanelSoal(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void AnswerButton(int answer)
    {
        soalManager.PlayerAnswer(answer);
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
