using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject startPanel;
    Animator heroAnimation;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject winPanel;
    public GameObject buton;
    bool stop = false;

    hatAdd hatAdd;
    public TextMeshProUGUI text;

    private void Awake()
    {
        Time.timeScale = 0f;
    }
    private void Start()
    {
        heroAnimation = GameObject.Find("Stickman").GetComponent<Animator>();
        hatAdd = FindObjectOfType<hatAdd>();
        buton.SetActive(false);
    }
    public void StartGame()
    {
        startPanel.SetActive(false);
        heroAnimation.SetTrigger("run");
        Time.timeScale = 1f;   
        buton.SetActive(true);

    }

    public void GameOver2()
    {
        Invoke("GameOver", 0.15f);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        heroAnimation.SetTrigger("lose");
        gameOverPanel.SetActive(true);   
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void menu()
    {
        SceneManager.LoadScene("Opening");
    }

    public void skor(int a)
    {
        text.text = "Score: " + a.ToString();
        winPanel.SetActive(true);
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void Level3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void pause() 
    {
        stop = !stop;

        if (stop)
        {
            Time.timeScale = 0f;    
            heroAnimation.speed= 0f;
        }
        else
        {
            Time.timeScale = 1f;
            heroAnimation.speed= 1f;

        }

    }



}
