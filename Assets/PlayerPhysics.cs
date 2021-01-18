using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Girl")
        {
            GameManager.Instance.WinGame();
        }
    }
}
