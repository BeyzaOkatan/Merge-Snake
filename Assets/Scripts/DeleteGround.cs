using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteGround : MonoBehaviour
{
    GroundGenerator groundGenerator;
    void Start()
    {
        groundGenerator = GameObject.FindObjectOfType<GroundGenerator>();
    }

    private void OnTriggerExit(Collider other)
    {
       // groundGenerator.generateGround();
        Destroy(gameObject,2f);
    }
}
