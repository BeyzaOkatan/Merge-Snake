using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatGenerator : MonoBehaviour
{
    [SerializeField] GameObject hatPrefab;
    Transform hero;
    float posZ;
    Vector3 posHat;

    private void Start()
    {
        hero = GameObject.Find("Stickman").GetComponent<Transform>();
        
        generateHat();
        
    }


    void generateHat()
    {
        float a = Random.RandomRange(-5.5f, 5.6f);
        int index = Random.Range(7, 10);

        posHat = new Vector3(a, hero.position.y +0.5f, transform.GetChild(index).position.z);
        Instantiate(hatPrefab, posHat, Quaternion.identity);

    }

}
