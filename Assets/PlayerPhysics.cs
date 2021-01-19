using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{

    [SerializeField]
    PlayerController player;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Girl")
        {
           player.Win();
        }
    }
}
