using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    hatAdd hatAdd;
    public GameObject hat;
    Animator winner;
    public GameObject winText;
    ButtonManager buttonManager;
    

    private void Start()
    {
        hatAdd = FindObjectOfType<hatAdd>();
        winner = GameObject.Find("Stickman").GetComponent<Animator>();
        buttonManager = FindObjectOfType<ButtonManager>();

    }

    private void OnTriggerEnter(Collider other)
    {
        float time;
        if(SceneManager.GetActiveScene().name == "Level1") {
            PlayerPrefs.SetInt("level", 1);
            time = 0.3f;
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            PlayerPrefs.SetInt("level", 2);
            time = 0.3f;
        }
        else
        {
            time = 0.3f;
        }
        Invoke("finishLine", time);
    }

    void finishLine()
    {
        Time.timeScale = 0;
        winner.SetBool("win", true);
        int hatNumber = hatAdd.hatList.Count;
        for (int i = 0; i < hatNumber; i++)
        {
            GameObject willdelete = hatAdd.hatList[hatAdd.hatList.Count - 1];
            hatAdd.hatList.Remove(willdelete);
            Destroy(willdelete);
        }

        StartCoroutine(hatcoroutine(hatNumber));

    }

    IEnumerator hatcoroutine(int hatNumber)
    {
        Vector3 currentPos = transform.position;
        yield return new WaitForSecondsRealtime(1f);
        for (int i = 0; i < hatNumber; i++)
        {
            yield return new WaitForSecondsRealtime(0.5f);
            Instantiate(hat, new Vector3(0, currentPos.y + 1.7f, currentPos.z + 20), Quaternion.identity);
            currentPos.y += 2f;

        }
        yield return new WaitForSecondsRealtime(1f);

        buttonManager.skor(hatNumber);

    }
}
