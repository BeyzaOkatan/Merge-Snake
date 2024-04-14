using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateGenerator : MonoBehaviour
{
    [SerializeField] GameObject gate;
    hatAdd hatAdd;
    List<GameObject> hatList;
    public List<GameObject> gateList;
    int gap1, gap2, gap3;
    void Start()
    {
        hatAdd = FindObjectOfType<hatAdd>();
        hatList = hatAdd.hatList;
        if(SceneManager.GetActiveScene().name == "Level1")
        {
            gap1 = 700;
            gap2 = 800;
            gap3 = 1700;
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            gap1 = 2000;
            gap2 = 500;
            gap3= 1300;
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            gap1 = 3500;
            gap2= 300;
            gap3 = 1100;
        }
        generateGate();
    }

    void generateGate()
    {
        int rand = UnityEngine.Random.Range(1, 5000);
        int rast = UnityEngine.Random.Range(1, 2000);
        int gateindex = UnityEngine.Random.Range(0, 2);

        if (rand<gap1)
        {
            Instantiate(gateList[gateindex], transform.GetChild(2).transform.position, Quaternion.identity, transform);
            Instantiate(gateList[Mathf.Abs(gateindex-1)], transform.GetChild(4).transform.position, Quaternion.identity, transform);
        }
        else
        {
            int index = UnityEngine.Random.Range(2, 5);
            Transform child = transform.GetChild(index).transform;

            if (rast < gap2)
            {
                Instantiate(gateList[1], child.position, Quaternion.identity, transform);
            }
            else if (rast > gap3)
            {
                Instantiate(gateList[0], child.position, Quaternion.identity, transform);
            }
            else
            {
                Instantiate(gateList[gateindex], child.position, Quaternion.identity, transform);
            }
        }




    }
}
