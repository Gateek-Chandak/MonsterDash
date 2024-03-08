using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public int score;
    public Text scoreDisplay;
    public Text endScore;
    public Text GOHighScore;
    public Text PauseHScore;
    public Text miniHS;
    public Text menuHS;

    public GameObject player;
    public GameObject newHSParticles;

    void Start()
    {
        if(menuHS != null)
        {
            menuHS.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        }
        if (PauseHScore != null && GOHighScore != null && miniHS != null)
        {
            GOHighScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0);
            PauseHScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0);
            miniHS.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        }
    } 

    private void Update()
    {
        if (player == null)
		{
            Destroy(gameObject);
		}

        if (scoreDisplay != null && endScore != null)
        {
            scoreDisplay.text = score.ToString();
            endScore.text = "Score: " + score.ToString();

            if (score > PlayerPrefs.GetInt("HighScore", 0))
            {
                Instantiate(newHSParticles, transform.position, Quaternion.identity);
                newHSParticles = null;
            }
            
        } 
        
    }

    void FixedUpdate()
    {
        if (PauseHScore != null && GOHighScore != null && miniHS != null)
        {
            while (score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", score);
                PauseHScore.text = "High Score: " + score;
                GOHighScore.text = "High Score: " + score;
                miniHS.text = score.ToString();
            }
        }
           
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        score++;
        Destroy(other.gameObject);
    }
}