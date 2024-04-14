using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class InputController : MonoBehaviour
{
    float horizontalValue;

    public float HorizontalValue
    {
        get { return horizontalValue; }
    }
    void Swipe()
    {
        if (Input.GetMouseButton(0))
        {
            horizontalValue = Input.GetAxis("Mouse X");
        }
        else
        {
            horizontalValue = 0;
        }
    }
    void Update()
    {
        Swipe();
    }
}
