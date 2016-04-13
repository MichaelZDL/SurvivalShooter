using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject enemyPrefab;
    public float timeSpawnEnemy = 3;
    public float timer = 0;


    void Start() {
        InvokeRepeating("AccelerateSpawn", 0, 1);
    }
    void Update() {
        timer += Time.deltaTime;
        if (timer >= timeSpawnEnemy) {
            timer -= timeSpawnEnemy;
            SpawnEnemy();
        }
    }

    void SpawnEnemy() {
        GameObject.Instantiate(enemyPrefab, transform.position, transform.rotation);
    }

    void AccelerateSpawn() {
        timeSpawnEnemy -= 0.05f;
    }
}
