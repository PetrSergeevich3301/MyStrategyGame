using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Father : MonoBehaviour
{

    public int odin;
    public int dva;

    // Update is called once per frame
    void Update()
    {
        if(odin == 1 && dva == 2)
        {
            Debug.Log("Принимаем решен");
        }
    }
}
