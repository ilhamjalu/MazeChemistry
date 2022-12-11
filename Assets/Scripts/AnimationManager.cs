using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetTouchInput())
        {
            anim.SetBool("isTap", true);
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

    public void PlayTheoryAnimation(Animator animParam)
    {
        animParam.SetTrigger("isPlay");
    }
}
