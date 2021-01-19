using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;
public class PlayerController : Singleton<PlayerController>
{
    public bool canPlay = true;
    //Playermodel will calculate physic operations.
    public GameObject playerModel;

    [SerializeField]
    private Animator playerAnim;
    //Girl animations
    [SerializeField]
    private Animator girlAnim;

    private bool isRunnning =false;
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

    //This is for rope initialize
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
        if(GameManager.Instance.gameState == GameManager.GameState.Play && canPlay)
        {
            if (joystick.Direction.magnitude != 0)
            {
                newPos = new Vector3(joystick.Direction.x, 0, joystick.Direction.y);
                playerModel.transform.forward = Vector3.Lerp(playerModel.transform.forward, newPos, Time.deltaTime * rotSpeed);
                rb.velocity = (playerModel.transform.forward.normalized) * speed;
                if (isRunnning == false)
                {
                    isRunnning = true;
                    playerAnim.SetBool("Run", true);
                }
            }
            else
            {
                rb.velocity = Vector3.zero;
                if (isRunnning == true)
                {
                    isRunnning = false;
                    playerAnim.SetBool("Run", false);
                }
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    
    }
   
    public void Dead()
    {
        StartCoroutine(DeathSequence());
    }
    IEnumerator DeathSequence()
    {
        playerAnim.SetBool("Lose", true);
        girlAnim.SetBool("Lose", true);
        canPlay = false;
        yield return new WaitForSeconds(1.5f);
        GameManager.Instance.LoseGame();
    }
    public void Win()
    {
        StartCoroutine(WinSequence());
    }
    IEnumerator WinSequence()
    {
        canPlay = false;
        playerAnim.SetBool("Win", true);
        girlAnim.SetBool("Win", true);
        yield return new WaitForSeconds(1.5f);
        GameManager.Instance.WinGame();
    }
}

