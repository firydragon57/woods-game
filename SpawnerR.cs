using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerR : MonoBehaviour
{
    public GameObject slideSlime;
    public GameObject healthSlime;
    public GameObject explosionSlime;
    public float spawnWait;
    public int startWait;
    private bool stop;
    private float randomNum;
    
    public PlayerController pc;
    private int score;

    void Start() {
        StartCoroutine(waitSpawner());
        score = pc.score;
    }

    void Update() {
        score = pc.score;
        if(score >= 70) {
            spawnWait = Random.Range(0.6f, 2f);
        }
        
        else if(score >= 50) {
            spawnWait = Random.Range(0.6f, 2.5f);
        }

        else if(score >= 40) {
            spawnWait = Random.Range(1.5f, 2f);
        }

        else if(score >= 30) {
            spawnWait = Random.Range(2.5f, 3);
        }

        else if(score >= 20) {
            spawnWait = Random.Range(3.5f, 4f);
        }

        else if(score >= 10) {
            spawnWait = Random.Range(4.5f, 5f);
        }

        else {
            spawnWait = Random.Range(5f, 5.5f);
        }

        if(pc.currentHealth <= 0) {
            Destroy(gameObject);
        }
    }

    IEnumerator waitSpawner() {
        yield return new WaitForSeconds (startWait);

        while(!stop) {
            randomNum = Random.Range(1f, 100f);
            if(randomNum > 20f && randomNum < 30f) {
                Spawn(healthSlime);
                yield return new WaitForSeconds(spawnWait);
            }
            
            else if(randomNum > 55f && randomNum < 60f) {
                Spawn(explosionSlime);
                yield return new WaitForSeconds(spawnWait);
            }
            
            else {
                Spawn(slideSlime);
                yield return new WaitForSeconds(spawnWait);
            }
            
        }
    }

    private void Spawn(GameObject slimeType) {
        GameObject slime = Instantiate(slimeType, transform.position, Quaternion.identity);
    }
}
