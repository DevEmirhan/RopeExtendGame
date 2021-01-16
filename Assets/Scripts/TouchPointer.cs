using UnityEngine;
using UnityEngine.UI;

public class TouchPointer : MonoBehaviour
{
    public Image pointer;

    void Update()
    {
        // Vector3 mousePos = Input.mousePosition;

        if(Input.GetMouseButton(0))
        {
            pointer.enabled = true;
            pointer.gameObject.transform.position = Input.mousePosition;
        }
        
        if(Input.GetMouseButtonUp(0))
        {
            pointer.enabled = false;
        }
    }
}
