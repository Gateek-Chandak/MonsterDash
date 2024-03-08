using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{


    [Header("Variables")]
    public float slowDowntime = 0.24f;
    public float yIncrement;
    public float maxH;
    public float minH;
    public float speed;
    public int health = 3;

    [Header("GameObjects")]
    public GameObject moveParticles;
    public GameObject hitParticles;

    [Header("Bools")]
    public bool isHit = false;
    public bool isSlow = false;

    [Header("Other")]
    public Text healthText;
    private Vector2 targetPos;
    public Animator anim;
    public uiManager uiManager;
    public GameObject moveSound;

    void Start()
    {
        targetPos = new Vector2(0, 0);
        isHit = false;
    }

    void Update()
    {
        //ANIMATION--------------------
        /*if (isHit == true)
        {
            StartCoroutine(hitTimer());
        }
        if (isHit == false)
        {
            anim.SetBool("hit", false);
        }*/

        //SLOW MOTION---------------------
        if (isSlow == false)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = slowDowntime;
        }

        //HEALTH-----------------------
        healthText.text = "" + health;

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        //MOVEMENT----------------------
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && transform.position.y < maxH && uiManager.isPaused == false)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + yIncrement);
            Instantiate(moveParticles, transform.position, Quaternion.identity);
	    Instantiate(moveSound, transform.position, Quaternion.identity);
            if (uiManager.isPaused == false)
            {
                cameraShake.shouldShake = true;
            } 
        }
        else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && transform.position.y > minH && uiManager.isPaused == false)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - yIncrement);
            Instantiate(moveParticles, transform.position, Quaternion.identity);
	    Instantiate(moveSound, transform.position, Quaternion.identity);
            if (uiManager.isPaused == false)
            {
                cameraShake.shouldShake = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("obstacle"))
        {
            Instantiate(hitParticles, transform.position, Quaternion.identity);
            isHit = true;
            StartCoroutine(slowDown());
        }
    }

    IEnumerator hitTimer()
    {      
        anim.SetBool("hit", true);
        yield return new WaitForSeconds(0.2f);
        isHit = false;

    }
    IEnumerator slowDown()
    {
        isSlow = true;
        Time.timeScale = slowDowntime;
        speed = 30f;
        yield return new WaitForSeconds(0.6f);
        speed = 180f;
        isSlow = false;
        Time.timeScale = 1;
    }
}
