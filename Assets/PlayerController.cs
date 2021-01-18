using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;
public class PlayerController : Singleton<PlayerController>
{
 
    public GameObject playerModel;
    private Rigidbody rb;
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float rotSpeed = 1f;
    [SerializeField]
    private float ropeSpeed = 1f;

    public ObiRope rope;
    public ObiRopeCursor cursor;
    private float currentLength;
    private float currentLengthHelper;
    private float increaseAmount;
    private float desiredLength;
    private bool isReady = false;
    private Vector3 newPos;

    [SerializeField]
    private Joystick joystick;


    void Start()
    {
        rb = playerModel.GetComponent<Rigidbody>();
        currentLength = rope.restLength;
        currentLengthHelper = currentLength;
        increaseAmount = currentLength / 10f;
    }

    // Update is called once per frame
    //void FixedUpdate()
    //{
    //    float mH = Input.GetAxis("Horizontal");
    //    float mV = Input.GetAxis("Vertical");
    //    rb.velocity = new Vector3(mH * speed, rb.velocity.y, mV * speed);
    //}
    public void ExtendRope(int power)
    {
        desiredLength = currentLength + (increaseAmount * power);
        //cursor.ChangeLength(desiredLength);
        currentLength = desiredLength;
        isReady = true;
    }

    private void Update()
    {
        if (isReady)
        {
            currentLengthHelper = Mathf.SmoothStep(currentLengthHelper, desiredLength, Time.deltaTime * ropeSpeed);

            cursor.ChangeLength(currentLengthHelper);
        }
        if (joystick.Direction.magnitude != 0)
        {
            //charAnimator.SetBool("isRunning", true);
            newPos = new Vector3(joystick.Direction.x, 0, joystick.Direction.y);
            playerModel.transform.forward = Vector3.Lerp(playerModel.transform.forward ,newPos,Time.deltaTime*rotSpeed);
            rb.velocity = (playerModel.transform.forward.normalized) * speed;
        }
        else
        {
            rb.velocity = Vector3.zero;
            //charAnimator.SetBool("isRunning", false);
        }


    }
   
    public void Dead(string msg)
    {
        GameManager.Instance.LoseGame();
    }

}

