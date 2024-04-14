using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuLevel : MonoBehaviour
{
    [SerializeField] Button[] buttons;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("level"))
        {
            PlayerPrefs.SetInt("level", -1);
        }
        for(int i = 1; i< buttons.Length; i++) {
            buttons[i].interactable = false;
        }
    }
    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Level2()
    {
         
        if (PlayerPrefs.GetInt("level")>=1)
        {
            SceneManager.LoadScene("Level2");
        }
    }

    public void Level3()
    {
        if (PlayerPrefs.GetInt("level")>=2)
        {
            SceneManager.LoadScene("Level3");
        }
    }

    private void Update()
    {
        int level = PlayerPrefs.GetInt("level");

        for(int i = 1; i< level+1; i++)
        {
            buttons[i].interactable = true;
        }
    }


}
