using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public float turnVel;
    public VariableJoystick variableJoystick;
    public CharacterController controller;
    public Animator walkAnimation;
    Quaternion updateRot;
    [SerializeField] AudioSource walkAudio;
    public bool canWalk;

    public void Update()
    {
        if (canWalk)
        {
            MoveChar();
        }
    }

    void MoveChar()
    {
        //Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        Vector3 direction = transform.right * variableJoystick.Horizontal + transform.forward * variableJoystick.Vertical;

        WalkAnim(direction);

        controller.Move(direction * speed * Time.deltaTime);

        transform.Rotate(0, variableJoystick.Horizontal * turnSpeed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "FinishPoint")
        {
            Debug.Log("TEST");
            GameManager gameManager = GameObject.Find("Manager").GetComponent<GameManager>();
            gameManager.GameDoneCheck();
        }
    }

    void WalkAnim(Vector3 direction)
    {
        if (direction != new Vector3(0, 0, 0))
        {
            walkAnimation.SetBool("isWalk", true);

            //walkAudio.Play();
        }
        else
        {
            walkAnimation.SetBool("isWalk", false);
        }
    }
}