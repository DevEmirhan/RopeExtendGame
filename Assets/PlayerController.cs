using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float ropeSpeed = 1f;

    public ObiRope rope;
    public ObiRopeCursor cursor;
    private float currentLength;
    private float currentLengthHelper;
    private float increaseAmount;
    private float desiredLength;
    private bool isReady = false;
   
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        currentLength = rope.restLength;
        currentLengthHelper = currentLength;
        increaseAmount = currentLength / 10f;
        Debug.Log("Rope length is" + currentLength);
        Debug.Log("Increase length is" + increaseAmount);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float mH = Input.GetAxis("Horizontal");
        float mV = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(mH * speed, rb.velocity.y, mV * speed);
    }
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
            currentLengthHelper = Mathf.SmoothStep(currentLengthHelper, desiredLength, Time.deltaTime*ropeSpeed);
            
            cursor.ChangeLength(currentLengthHelper);
        }
    }

}

