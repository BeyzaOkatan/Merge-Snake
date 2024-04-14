using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnifeGenerator : MonoBehaviour
{
    [SerializeField] GameObject knife;
    Vector3 newRotation = new Vector3(0, 180, 0);
    Vector3 newPosition;
    Vector3 newPosition2;
    BoxCollider col;
    int gap1;

    void Start()
    {
        col = knife.GetComponent<BoxCollider>();
        newPosition = transform.GetChild(5).transform.position;
        newPosition2 = transform.GetChild(6).transform.position;
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            gap1 = 1000;
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            gap1 = 2000;
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            gap1 = 3500;
        }

        generateKnife();

        
    }

    void generateKnife()
    {
        int rand = Random.Range(1, 5000);
        int a = Random.Range(3, 4);
        knife.transform.localScale= new Vector3(knife.transform.localScale.x, a, knife.transform.localScale.z);
       // col.transform.position = new Vector3(col.transform.position.x, (knife.transform.position.y - col.transform.position.y), col.transform.position.z) * a;
       // col.transform.localScale = new Vector3(col.transform.localScale.x, a, col.transform.localScale.z);


        if (rand < gap1)
        {
            Instantiate(knife, newPosition, Quaternion.identity, transform);
            Instantiate(knife, newPosition2, Quaternion.Euler(newRotation), transform);

        }
    }
}
