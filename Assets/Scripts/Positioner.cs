using UnityEngine;

[ExecuteInEditMode]
public class Positioner : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    void Update()
    {
        gameObject.transform.position = target.transform.position + offset;
    }
}
