using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundGenerator : MonoBehaviour
{
    [SerializeField] GameObject ground;
    [SerializeField] GameObject finishGround;
    Vector3 nextGround;
    int groundNumber;
    void Start()
    {
        nextGround = GameObject.Find("Stickman").transform.position;
        nextGround = new Vector3(nextGround.x,nextGround.y, nextGround.z+20);
        if (SceneManager.GetActiveScene().name == "Level1") {
            groundNumber = 15;
        }
        else if(SceneManager.GetActiveScene().name == "Level2")
        {
            groundNumber = 15;
        }
        else
        {
            groundNumber = 15;
        }

        for (int i =0; i<groundNumber; i++)
        {
            generateGround();
        }
        Instantiate(finishGround, nextGround, Quaternion.identity);

    }
    public void generateGround()
    {
        GameObject tmp = Instantiate(ground, nextGround, Quaternion.identity);
        nextGround = tmp.transform.GetChild(1).transform.position;
    }
}
