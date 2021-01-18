using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeExtender : MonoBehaviour
{
    private bool isActive = true;
    public int IncreasePower = 1;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && isActive)
        {
            other.gameObject.GetComponentInParent<PlayerController>().ExtendRope(IncreasePower);
            isActive = false;
            Destroy(gameObject);
        }
    }



}

