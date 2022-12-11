using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenManager : MonoBehaviour
{
    [SerializeField] GameObject tapText;
    [SerializeField] GameObject character;
    [SerializeField] GameObject canvas;
    [SerializeField] bool isTap;

    // Start is called before the first frame update
    void Start()
    {
        LeanTween.scale(tapText, new Vector3(2, 2, 2), 1f).setLoopPingPong();
        LeanTween.move(tapText, new Vector3(2, 2, 2), 5f).setOnComplete(() => 
            tapText.SetActive(false));
        LeanTween.alphaCanvas(canvas.GetComponent<CanvasGroup>(), 1, 1f);
    }

    void Update()
    {
        if (GetTouchInput())
        {
            //anim
        }
        else
        {
        }
    }

    bool GetTouchInput()
    {
        if (Input.touches.Length > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Ended)
            {
                Debug.Log("TAP DONE");
                return true;
            }
        }
        return false;
    }

    private void OnMouseDown()
    {
        isTap = true;
    }
}
