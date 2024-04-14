using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class hatAdd : MonoBehaviour
{
    public List<GameObject> hatList = new List<GameObject>();
    public TextMeshProUGUI text;
    public GameObject hat;

    private void Start()
    {
   
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="hat")
        {
            if (hatList.Count > 0)
            {
                other.transform.position = new Vector3(transform.position.x + 0.22f, hatList[hatList.Count - 1].transform.position.y +0.75f,transform.position.z + 0.32f);
            }
            else
            {
                other.transform.position = new Vector3(transform.position.x + 0.22f,transform.position.y + 4.6f, transform.position.z + 0.32f);
     

            }

            hatList.Add(other.gameObject);
            

           other.gameObject.transform.SetParent(transform);
        }


    }

   


}
