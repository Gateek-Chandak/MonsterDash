using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    public GameObject player;
    [Header("GameOver")]
    public GameObject gameOverText;

    [Header("Pause")]
    public GameObject pauseText;
    public bool isPaused = false;

    [Header("Sounds")]
    public GameObject menuOpen;
    public GameObject clickSound;
    public GameObject startGame;

    [Header("LoadASYNC")]
    public GameObject loadingScreen;
    public GameObject title;
    public GameObject title2;
    public Slider slider;


    void Start()
    {
        gameOverText.SetActive(false);
        pauseText.SetActive(false);
        isPaused = false;

        loadingScreen.SetActive(false);
    }

    void Update()
    {
        if (player == null)
        {
            gameOverText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(startGame, transform.position, Quaternion.identity);
                gameOverText.SetActive(false);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if (isPaused == false && Input.GetKeyDown(KeyCode.P) && player != null)
        {
            Instantiate(menuOpen, transform.position, Quaternion.identity);
            isPaused = true;
        }
        else if (isPaused == true && Input.GetKeyDown(KeyCode.P))
        {
            Instantiate(menuOpen, transform.position, Quaternion.identity);
            isPaused = false;
            Time.timeScale = 1;
        }


        if (isPaused == true)
        {
            Time.timeScale = 0;
            pauseText.SetActive(true);
        }
        else
        {
            pauseText.SetActive(false);
        }

    }

    public void exitButton()
    {
        Instantiate(clickSound, transform.position, Quaternion.identity);
        Time.timeScale = 1;

        StartCoroutine(LoadAsynchronously());

        //SceneManager.LoadScene("Menu");

    }

    IEnumerator LoadAsynchronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Menu");

        loadingScreen.SetActive(true);
        title.SetActive(false);
        title2.SetActive(false);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;

            yield return null;
        }
    }

}
