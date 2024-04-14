using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementController : MonoBehaviour
{
    public float forwardSpeed;
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float horizontalLimit;
    private InputController InputController;
    float newHorizontalPos;


    private void Start()
    {
        InputController = FindObjectOfType<InputController>();

        if(SceneManager.GetActiveScene().name == "Level1")
        {
            forwardSpeed = 40;
        }
        else if(SceneManager.GetActiveScene().name == "Level2")
        {
            forwardSpeed = 40;
        }
        else if(SceneManager.GetActiveScene().name == "Level3")
        {
            forwardSpeed= 40;
        }
    }
    private void FixedUpdate()
    {
        HeroForwardMovement();
        HorizontalMovement();
    }

    void HeroForwardMovement()
    {
        transform.Translate(transform.forward * forwardSpeed * Time.fixedDeltaTime);
    }
  

    void HorizontalMovement()
    {
        newHorizontalPos = transform.position.x + InputController.HorizontalValue * horizontalSpeed * Time.fixedDeltaTime;
        newHorizontalPos = Mathf.Clamp(newHorizontalPos, -horizontalLimit, horizontalLimit);
        transform.position = new Vector3(newHorizontalPos, transform.position.y, transform.position.z);
    }




}
