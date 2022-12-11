using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class QuizActivation : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Button quizButton;
    [SerializeField] ButtonScript buttonScript;
    [SerializeField] float distance;
    [SerializeField] GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnDistance();
    }

    void OnDistance()
    {
        foreach(GameObject lamp in GameObject.FindGameObjectsWithTag("Lamp"))
        {
            bool IsDone()
            {
                foreach (int temp in gameManager.soalDone)
                {
                    if (temp.ToString() == lamp.name)
                    {
                        return true;
                    }
                }
                return false;
            }

            if (Vector3.Distance(player.transform.position, lamp.transform.position) < distance && !IsDone())
            {
                buttonScript.indexSoal = int.Parse(lamp.name);
                quizButton.interactable = true;

                return;
            }
        }

        quizButton.interactable = false;

    }

    
}
