using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatRandomPlace : MonoBehaviour
{

    [SerializeField] hatAdd hatAdd;
    int hatindex = -1;
    Vector3 currentPos;

    private void Start()
    {
        hatAdd = FindObjectOfType<hatAdd>();
    }
 
        private void OnTriggerEnter(Collider other)
       {
           if (other.gameObject.tag == "hat")
           {
               foreach(GameObject var in hatAdd.hatList)
               {
                   if(var == other.gameObject)
                   {
                    hatindex = hatAdd.hatList.IndexOf(var);
                       break;
                   }
               }
               if(hatindex != -1)
            {
                for (int i = 0; i < hatAdd.hatList.Count - hatindex; i++)
                {
                    GameObject flyinghat = hatAdd.hatList[hatAdd.hatList.Count - 1];
                    flyinghat.transform.parent = null;
                    hatAdd.hatList.Remove(flyinghat);
                    //Destroy(flyinghat);
                    StartCoroutine(SmoothLerp(flyinghat, 0.4f));
                }
            }
               
           }
       }

    private IEnumerator SmoothLerp(GameObject hat, float time)
    {
        Vector3 startingPos = hat.transform.position;
        int posx = Random.Range(-10, 10);
        float posy = -10;
        int posz = Random.Range(30, 35);
        if(posx <-6)
        {
            if(startingPos.x < 0)
                posx = -20;
            else
                posx = 20;

        }
        else if (posx>6)
        {
            if(startingPos.x > 0)
                posx = 20;
            else
                posx = -20;
        }
        else
        {
            posy = 0.88f;
        }

        Vector3 finalPos = new Vector3(posx,posy,startingPos.z+ posz);
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            hat.transform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
