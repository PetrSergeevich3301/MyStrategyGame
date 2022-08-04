using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    bool isCollision;

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        isCollision = true;
    }
    private void OnCollisionExit(UnityEngine.Collision collision)
    {
        isCollision = false;
    }
    public bool CheckCollision()
    {
        return isCollision;
    }
}
