using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{
    public Text menuHS;

    public GameObject loadingScreen;
    public GameObject title;
    public Slider slider;

    public GameObject clickSound;
    public GameObject startGameSound;

    void Start()
    {
        Time.timeScale = 1;
        loadingScreen.SetActive(false);
        title.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //SceneManager.LoadScene("Main");
            Instantiate(startGameSound, transform.position, Quaternion.identity);
            StartCoroutine(LoadAsynchronously());
        }
    }

    IEnumerator LoadAsynchronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Main");

        loadingScreen.SetActive(true);
        title.SetActive(false);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;

            yield return null;
        }
    }

    public void resetHS()
    {
        PlayerPrefs.DeleteKey("HighScore");
        menuHS.text = "0";

        Instantiate(clickSound, transform.position, Quaternion.identity);
    }
}