using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathHolder : MonoBehaviour
{
    public List<Transform> path;
    private int index = 0;
    public bool collected;
    private void Start()
    {
        index = 0;
    }

    public Transform CurrentPath()
    {
        return path[index];
    }

    public Vector3 NextPathPosition()
    {
        index++;
        if (index > path.Count - 1)
        {
            index = 0;
        }
        return path[index].position;
    }
}
