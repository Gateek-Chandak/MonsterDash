using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    
    public int damage = 1;
    public float speed = 5;

    public GameObject dieParticles;
    public GameObject healthParticlesLoc;

    public GameObject healthParticles;

    public GameObject playerHit;
    public GameObject enemyDestroy;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        healthParticlesLoc = GameObject.FindGameObjectWithTag("HPL");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Instantiate(dieParticles, transform.position, Quaternion.identity);
            cameraShake.shouldShake = true;

            Instantiate(playerHit, transform.position, transform.rotation);

            col.GetComponent<Player>().health -= damage;
            Instantiate(healthParticles, healthParticlesLoc.transform.position, healthParticlesLoc.transform.rotation);
            Destroy(gameObject);
        }
	if (col.CompareTag("score"))
        {
            Instantiate(dieParticles, transform.position, Quaternion.identity);
	    Instantiate(enemyDestroy, transform.position, Quaternion.identity);
	        Destroy(gameObject);
	        cameraShake.shouldShake = true;
        }
    }

}
