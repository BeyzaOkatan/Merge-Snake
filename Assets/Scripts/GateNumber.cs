using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;


public class GateNumber : MonoBehaviour
{
    TextMeshProUGUI text;
    [SerializeField] GameObject hat;
    [SerializeField] hatAdd hatAdd;
    ButtonManager buttonManager;
    Vector3 newPos;
    int[] textSayi = { -3, -2, 2, 3 };
    int index = -1;
    string bas;
    Animator loser;

    private void Start()
    {
        buttonManager = FindObjectOfType<ButtonManager>();
        text = gameObject.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>();
        hatAdd = FindObjectOfType<hatAdd>();
        loser = GameObject.Find("Stickman").GetComponent<Animator>();

        if (gameObject.tag == "gate1")
        {
            index = Random.Range(0, 2);
        }
        else
        {
            index = Random.Range(2, 4);
        }

        if (index > 1)
        {
            bas = "+";
        }
        else
        {
            bas = "";
        }
        text.text = bas + textSayi[index].ToString();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Stickman")
        {
            int a = int.Parse(text.text);
            for (int i = 0; i < a; i++)
            {

                if (hatAdd.hatList.Count > 0)
                {
                    newPos = new Vector3(other.transform.position.x + 0.22f, hatAdd.hatList[hatAdd.hatList.Count - 1].transform.position.y + 0.75f, other.transform.position.z + 0.32f);
                }
                else
                {
                    newPos = new Vector3(other.transform.position.x + 0.22f, other.transform.position.y + 4.6f, other.transform.position.z + 0.32f);
                }
                GameObject inst = Instantiate(hat, newPos, Quaternion.identity);
                hatAdd.hatList.Add(inst);
                inst.transform.SetParent(other.transform);
            }
            if (hatAdd.hatList.Count + a < 0)
            {
                for (int i = hatAdd.hatList.Count -1; i >=0; i--)
                {
                    GameObject willdelete = hatAdd.hatList[hatAdd.hatList.Count - 1];
                    hatAdd.hatList.Remove(willdelete);
                    Destroy(willdelete);
                }
                buttonManager.GameOver2();
            }
            else
            {
                for (int i = 0; i > a; i--)
                {
                    GameObject willdelete = hatAdd.hatList[hatAdd.hatList.Count - 1];
                    hatAdd.hatList.Remove(willdelete);
                    Destroy(willdelete);
                }
            }


        }
        Debug.Log(hatAdd.hatList.Count);

    }


}