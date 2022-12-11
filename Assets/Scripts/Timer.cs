using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI TextTimer;
    public float time;
    public bool runTimer = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (runTimer)
        {
            SetText();
            CountTimer();
        }
    }

    public bool TimeUp()
    {
        if (time <= 0)
        {
            time = 0;
            runTimer = false;

            return true;
        }

        return false;
    }

    void CountTimer()
    {
        time -= Time.deltaTime;
    }

    void SetText()
    {
        int Menit = Mathf.FloorToInt(time / 60); //01
        int Detik = Mathf.FloorToInt(time % 60); //30
        TextTimer.text = Menit.ToString("00") + ":" + Detik.ToString("00");
    }
}
