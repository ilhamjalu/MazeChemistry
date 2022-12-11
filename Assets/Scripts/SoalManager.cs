using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoalManager : MonoBehaviour
{
    public SoalScript[] dataSoal;

    [SerializeField] List<GameObject> imageQuestion; 
    [SerializeField] TextMeshProUGUI soalText;
    [SerializeField] Button[] jawaban;
    [SerializeField] GameObject soalObj;
    [SerializeField] GameObject pembahasanObj;
    [SerializeField] GameManager gameManager;

    public int indexJawaban;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SoalText(int index)
    {
        soalObj.SetActive(true);

        if(dataSoal[index].soal != "")
        {
            soalObj.transform.Find("SoalText").GetComponent<TextMeshProUGUI>().text = dataSoal[index].soal;

            HideImageQuestion();
        }
        else
        {
            soalObj.transform.Find("SoalText").GetComponent<TextMeshProUGUI>().text = "";

            foreach (GameObject temp in imageQuestion)
            {
                if(temp.name == index.ToString())
                {
                    temp.SetActive(true);
                }
            }
        }

        indexJawaban = index;
        ButtonText(index);
    }

    public void HideImageQuestion()
    {
        foreach (GameObject temp in imageQuestion)
        {
            if (temp.activeInHierarchy)
            {
                temp.SetActive(false);
            }
        }
    }

    public void PembahasanText()
    {
        pembahasanObj.transform.Find("PembahasanText").GetComponent<TextMeshProUGUI>().text = dataSoal[indexJawaban].pembahasan;
    }

    public void PlayerAnswer(int answer)
    {
        Debug.Log("KLIK JAWABAN");
        if (answer == dataSoal[indexJawaban].indexBenar)
        {
            Debug.Log("BENAR");
            HideImageQuestion();

            gameManager.CheckAnswer(true);
            gameManager.ActivateLamp(indexJawaban);
            gameManager.AddDoneQuestion(indexJawaban);
        }
        else
        {
            Debug.Log("SALAH");
            HideImageQuestion();

            gameManager.CheckAnswer(false);
            Debug.Log("GAMEOBJECT NAME : " + indexJawaban.ToString());
        }
    }

    void ButtonText(int index)
    {
        for(int i = 0; i < 5; i++)
        {
            jawaban[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = dataSoal[index].jawab[i];
        }
    }
}
