using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform heroTransform;
    Vector3 distance;
    private void Start()
    {
        distance = heroTransform.position - transform.position;
    }
    private void LateUpdate()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, heroTransform.position.z - distance.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, 1);
    }
}
