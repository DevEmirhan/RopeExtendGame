using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    private Vector3 targetpos;
    float xVal;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.gameState == GameManager.GameState.Play)
        {
            xVal = target.transform.position.x;
            targetpos = new Vector3(xVal, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetpos, 0.2f);
        }
       
    }
}
